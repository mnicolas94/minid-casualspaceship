using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jnk.TinyContainer;
using ModelView;
using TNRD;
using UnityAtoms.BaseAtoms;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
using Unlockables;

namespace Skins.UI
{
    public class SkinsStore : MonoBehaviour
    {
        [SerializeField] private AssetLabelReference _skinsReference;
        
        [SerializeField] private SerializableInterface<IUnlockablesStorage<AddressableSkinData>> _storage;
        [SerializeField] private SkinDataEvent _equipEvent;
        [SerializeField] private SkinDataEvent _costPaidEvent;
        
        [SerializeField] private ViewList _unlockedList;
        [SerializeField] private ViewList _lockedList;

        private CancellationTokenSource _cts;

        private void OnEnable()
        {
            _equipEvent.Register(EquipSkin);
            _costPaidEvent.Register(UnlockSkin);
            _storage.Value.UnlockedEvent += OnSkinUnlocked;
        }

        private void OnDisable()
        {
            _equipEvent.Unregister(EquipSkin);
            _costPaidEvent.Unregister(UnlockSkin);
            _storage.Value.UnlockedEvent -= OnSkinUnlocked;
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
            var skins = await LoadAddressableSkinsAsync();
            foreach (var skinData in skins)
            {
                var unlocked = await _storage.Value.IsUnlocked(skinData, ct);
                AddSkinToList(skinData, unlocked);
            }
        }

        private async Task<IEnumerable<AddressableSkinData>> LoadAddressableSkinsAsync()
        {
            var resourceLocations = await Addressables.LoadResourceLocationsAsync(_skinsReference, typeof(SkinData)).Task;
            var skins = resourceLocations
                .Select(loc =>
                {
#if UNITY_EDITOR
                    var guid = AssetDatabase.AssetPathToGUID(loc.PrimaryKey);
#else
                    var guid = loc.PrimaryKey;
#endif
                    return new AddressableSkinData(guid);
                });
            return skins;
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
        
        private async void AddSkinToList(AddressableSkinData skinData, bool unlocked)
        {
            var listToAdd = unlocked ? _unlockedList : _lockedList;
            var listToRemove = unlocked ? _lockedList : _unlockedList;
            
            if (!listToAdd.IsModelInList(skinData))
            {
                var view = (SkinView) listToAdd.Add(skinData);
                view.Unlocked = unlocked;
                TinyContainer.Global.Get<SkinEquipper>(out var equipper);
                view.Equipped = await equipper.IsEquipped(skinData);
            }

            if (listToRemove.IsModelInList(skinData))
            {
                listToRemove.Remove(skinData);
            }
            
            // TODO keep order
            
            // make sure layouts get re-built after adding elements to them
            await Task.Yield();
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)_unlockedList.transform);
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)_lockedList.transform);
        }

        private void EquipSkin(AddressableSkinData skin)
        {
            TinyContainer.Global.Get<SkinEquipper>(out var equipper);
            equipper.EquipSkin(skin);
            
            // update equipped hint
            _unlockedList.GetViews<SkinView>().ForEach(v => v.Equipped = v.Model == skin);
        }
            
        private async void UnlockSkin(AddressableSkinData skin)
        {
            await _storage.Value.Unlock(skin, _cts.Token);
        }

        private void OnSkinUnlocked(AddressableSkinData skinData)
        {
            AddSkinToList(skinData, true);
        }
    }
}
