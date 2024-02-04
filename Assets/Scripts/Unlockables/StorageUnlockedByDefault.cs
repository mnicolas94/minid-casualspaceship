using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Unlockables
{
    public class StorageUnlockedByDefault<T> : ScriptableObject, IUnlockablesStorage<T>
    {
        [SerializeField] private List<T> _list;

        public async Task Initialize(CancellationToken ct)
        {
            
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
            
        }

        public Action<T> UnlockedEvent { get; set; }
    }
}