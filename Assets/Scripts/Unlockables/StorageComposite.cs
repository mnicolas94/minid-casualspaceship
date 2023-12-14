using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TNRD;
using UnityEngine;

namespace Unlockables
{
    public class StorageComposite<T> : ScriptableObject, IUnlockablesStorage<T>
    {
        [SerializeField] private List<SerializableInterface<IUnlockablesStorage<T>>> _storages;

        public async Task Initialize(CancellationToken ct)
        {
            var tasks = _storages.ConvertAll(storage => storage.Value.Initialize(ct));
            
            // register listener
            foreach (var storageInterface in _storages)
            {
                var storage = storageInterface.Value;
                storage.UnlockedEvent += UnlockedEvent;
            }
            
            await Task.WhenAll(tasks);
        }

        public async Task Dispose(CancellationToken ct)
        {
            var tasks = _storages.ConvertAll(storage => storage.Value.Dispose(ct));
            
            // unregister listener
            foreach (var storageInterface in _storages)
            {
                var storage = storageInterface.Value;
                storage.UnlockedEvent -= UnlockedEvent;
            }
            
            await Task.WhenAll(tasks);
        }

        public async Task<bool> IsUnlocked(T t, CancellationToken ct)
        {
            foreach (var storageInterface in _storages)
            {
                var storage = storageInterface.Value;
                var unlocked = await storage.IsUnlocked(t, ct);
                if (unlocked)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task Unlock(T t, CancellationToken ct)
        {
            foreach (var storageInterface in _storages)
            {
                var storage = storageInterface.Value;
                await storage.Unlock(t, ct);
            }
        }

        public Action<T> UnlockedEvent { get; set; }
    }
}