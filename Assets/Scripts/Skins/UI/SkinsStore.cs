using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ModelView;
using TNRD;
using UnityEngine;
using Unlockables;

namespace Skins.UI
{
    public class SkinsStore : MonoBehaviour
    {
        [SerializeField] private List<SkinData> _skins;
        [SerializeField] private List<SerializableInterface<IUnlockablesStorage<SkinData>>> _storages;

        [SerializeField] private ViewList _unlockedList;
        [SerializeField] private ViewList _lockedList;

        private CancellationTokenSource _cts;

        private async void Start()
        {
            _cts = new CancellationTokenSource();
            var ct = _cts.Token;

            // initialize storages
            var initializeTasks = _storages.ConvertAll(storage
                => storage.Value.Initialize(ct));
            await Task.WhenAll(initializeTasks);
            
            // load skins
            foreach (var skinData in _skins)
            {
                var unlocked = await IsUnlocked(skinData, ct);
                var listToAdd = unlocked ? _unlockedList : _lockedList;
                var listToRemove = unlocked ? _lockedList : _unlockedList;

                if (!listToAdd.IsModelInList(skinData))
                {
                    listToAdd.Add(skinData);
                }
                
                if (listToRemove.IsModelInList(skinData))
                {
                    listToRemove.Remove(skinData);
                }
            }
            
            // register unlock callbacks
            foreach (var serializableInterface in _storages)
            {
                var storage = serializableInterface.Value;
                storage.UnlockedEvent += OnSkinUnlocked;
            }
        }

        private void OnDestroy()
        {
            try
            {
                // unregister unlock callbacks
                foreach (var serializableInterface in _storages)
                {
                    var storage = serializableInterface.Value;
                    storage.UnlockedEvent -= OnSkinUnlocked;
                }
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

        private async Task<bool> IsUnlocked(SkinData skinData, CancellationToken ct)
        {
            foreach (var storageInterface in _storages)
            {
                var storage = storageInterface.Value;
                var unlocked = await storage.IsUnlocked(skinData, ct);
                if (unlocked)
                {
                    return true;
                }
            }

            return false;
        }

        private void OnSkinUnlocked(SkinData skinData)
        {
            if (!_unlockedList.IsModelInList(skinData))
            {
                _unlockedList.Add(skinData);
            }
            
            if (_lockedList.IsModelInList(skinData))
            {
                _lockedList.Remove(skinData);
            }
            
            // TODO keep order
        }
    }
}
