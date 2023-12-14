using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SaveSystem;
using UnityAtoms;
using UnityEngine;

namespace Unlockables
{
    public abstract class StorageLocal<T> : ScriptableObject, IUnlockablesStorage<T>
    {
        [SerializeField] private List<T> _list;

        public async Task Initialize(CancellationToken ct)
        {
            await this.Load();
        }

        public async Task Dispose(CancellationToken ct)
        {
            
        }

        public async Task<bool> IsUnlocked(T t, CancellationToken ct)
        {
            return _list.Contains(t);
        }

        public async Task Unlock(T t, CancellationToken ct)
        {
            _list.Add(t);
            await this.Save();
            UnlockedEvent.Invoke(t);
        }

        public Action<T> UnlockedEvent { get; set; }
    }
}