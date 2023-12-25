using System;
using System.Threading;
using System.Threading.Tasks;
using SaveSystem;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Unlockables;

namespace Currency
{
    [Serializable]
    public class CurrencyCost : IUnlockCost
    {
        [SerializeField] private IntReference _cost;
        public IntReference Cost => _cost;
        
        [SerializeField] private Currency _currency;
        public Currency Currency => _currency;

        public async Task<bool> CanAfford(CancellationToken ct)
        {
            return _currency.Variable.Value >= _cost.Value;
        }

        public async Task<bool> PayCost(CancellationToken ct)
        {
            var canAfford = await CanAfford(ct);
            Debug.Log($"canAfford={canAfford}");
            Debug.Log($"currency={_currency.Variable.Value}; {_currency.Variable}; {_currency}");
            Debug.Log($"currency guid={AssetGuidsDatabase.Instance.GetGuid(_currency.Variable)}");
            Debug.Log($"cost={_cost.Value}");
            if (canAfford)
            {
                _currency.Variable.Value -= _cost;
                await _currency.Variable.Save();
            }

            return canAfford;
        }
    }
}