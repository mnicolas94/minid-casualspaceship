using System;
using System.Collections.Generic;
using SaveSystem;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Currency
{
    public class GameOverCurrenciesUpdater : MonoBehaviour
    {
        [SerializeField] private List<Currency> _currencies;

        private void OnEnable()
        {
            CollectCurrencies();
        }

        private void CollectCurrencies()
        {
            foreach (var currency in _currencies)
            {
                currency.Variable.Value += currency.CurrentInGame.Value;
                currency.CurrentInGame.Value = 0;
            }
        }
    }
}