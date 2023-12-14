using System;
using System.Threading.Tasks;
using SaveSystem;
using UnityAtoms.BaseAtoms;
using UnityEngine;
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

        public async Task<bool> CanAfford()
        {
            return _currency.Variable.Value >= _cost.Value;
        }

        public async Task<bool> PayCost()
        {
            var canAfford = await CanAfford();
            if (canAfford)
            {
                _currency.Variable.Value -= _cost;
                await _currency.Save();
            }

            return canAfford;
        }
    }
}