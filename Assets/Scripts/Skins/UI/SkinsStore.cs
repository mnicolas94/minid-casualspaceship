using System;
using System.Threading;
using System.Threading.Tasks;
using Jnk.TinyContainer;
using ModelView;
using TNRD;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Unlockables;

namespace Skins.UI
{
    public class SkinsStore : MonoBehaviour
    {
        [SerializeField] private AssetLabelReference _skinsReference;
        
        [SerializeField] private SerializableInterface<IUnlockablesStorage<SkinData>> _storage;
        [SerializeField] private SkinDataEvent _equipEvent;
        [SerializeField] private SkinDataEvent _costPaidEvent;
        
        [SerializeField] private ViewList _unlockedList;
        [SerializeField] private ViewList _lockedList;

        private CancellationTokenSource _cts;

        private void OnEnable()
        {
            _equipEvent.Register(EquipSkin);
            _costPaidEvent.Register(UnlockSkin);
        }

        private void OnDisable()
        {
            _equipEvent.Unregister(EquipSkin);
            _costPaidEvent.Unregister(UnlockSkin);
        }

        private async void Start()
        {
            _cts = new CancellationTokenSource();
            var ct = _cts.Token;

            // initialize storage
            await _storage.Value.Initialize(ct);
            
            // clear lists
            _unlockedList.Clear();
            _lockedList.Clear();
            
            // load skins
            var skins = await Addressables.LoadAssetsAsync<SkinData>(_skinsReference, null).Task;
            foreach (var skinData in skins)
            {
                var unlocked = await _storage.Value.IsUnlocked(skinData, ct);
                AddSkinToList(skinData, unlocked);
            }

            // make sure layouts get re-built after adding elements to them
            await Task.Yield();
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)_unlockedList.transform);
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)_lockedList.transform);
            
            // register unlock callback
            _storage.Value.UnlockedEvent += OnSkinUnlocked;
        }

        private async void OnDestroy()
        {
            try
            {
                // dispose storage
                await _storage.Value.Dispose(_cts.Token);
                
                // unregister unlock callback
                _storage.Value.UnlockedEvent -= OnSkinUnlocked;
            }
            finally
            {
                if (!_cts.IsCancellationRequested)
                {
                    _cts.Cancel();
                }

                _cts.Dispose();
                _cts = null;
            }
        }
        
        private void AddSkinToList(SkinData skinData, bool unlocked)
        {
            var listToAdd = unlocked ? _unlockedList : _lockedList;
            var listToRemove = unlocked ? _lockedList : _unlockedList;
            
            if (!listToAdd.IsModelInList(skinData))
            {
                var view = (SkinView) listToAdd.Add(skinData);
                view.Unlocked = unlocked;
            }

            if (listToRemove.IsModelInList(skinData))
            {
                listToRemove.Remove(skinData);
            }
            
            // TODO keep order
        }

        private void EquipSkin(SkinData skin)
        {
            Debug.Log($"Equip skin: {skin}");
            TinyContainer.Global.Get<SkinEquipper>(out var equipper);
            equipper.EquipSkin(skin);
        }
            
        private async void UnlockSkin(SkinData skin)
        {
            Debug.Log($"Unlock skin: {skin}");
            await _storage.Value.Unlock(skin, _cts.Token);
        }

        private void OnSkinUnlocked(SkinData skinData)
        {
            AddSkinToList(skinData, true);
        }
    }
}
