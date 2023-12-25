﻿using System;
using System.Threading;
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

        public async Task<bool> CanAfford(CancellationToken ct)
        {
            return _currency.Variable.Value >= _cost.Value;
        }

        public async Task<bool> PayCost(CancellationToken ct)
        {
            var canAfford = await CanAfford(ct);
            Debug.Log($"canAfford={canAfford}");
            Debug.Log($"currency={_currency.Variable.Value}");
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