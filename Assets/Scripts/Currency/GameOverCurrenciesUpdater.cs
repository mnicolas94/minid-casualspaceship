using System;
using SaveSystem;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Currency
{
    public class GameOverCurrenciesUpdater : MonoBehaviour
    {
        [SerializeField] private IntReference _currentSoftCurrency;
        [SerializeField] private IntReference _currentHardCurrency;
        [SerializeField] private IntVariable _totalSoftCurrency;
        [SerializeField] private IntVariable _totalHardCurrency;

        private void OnEnable()
        {
            CollectCurrencies();
        }

        private void CollectCurrencies()
        {
            _totalSoftCurrency.Value += _currentSoftCurrency;
            _totalHardCurrency.Value += _currentHardCurrency;
            
            _currentSoftCurrency.Value = 0;
            _currentHardCurrency.Value = 0;
        }
    }
}