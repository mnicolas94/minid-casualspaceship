using System;
using System.Collections.Generic;
using System.Threading;
using ModelView;
using UnityEngine;
using Unlockables;

namespace Skins.UI
{
    public class SkinsStore : MonoBehaviour
    {
        [SerializeField] private List<SkinData> _skins;

        [SerializeField] private ViewList _unlockedList;
        [SerializeField] private ViewList _lockedList;

        private CancellationTokenSource _cts;
        
        private async void OnEnable()
        {
            _cts = new CancellationTokenSource();

            foreach (var skinData in _skins)
            {
                if (skinData.Unlockable is ILoadable loadable)
                {
                    await loadable.Load(_cts.Token);
                }

                var unlocked = skinData.Unlockable.IsUnlocked();
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
        }

        private void OnDisable()
        {
            if (!_cts.IsCancellationRequested)
            {
                _cts.Cancel();
            }

            _cts.Dispose();
            _cts = null;
        }
    }
}