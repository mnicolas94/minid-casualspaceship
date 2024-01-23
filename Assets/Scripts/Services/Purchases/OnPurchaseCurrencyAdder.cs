using System;
using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Purchasing;
using Utils.Attributes;

namespace Services.Purchases
{
    public class OnPurchaseCurrencyAdder : MonoBehaviour
    {
        [SerializeField, AutoProperty] private CodelessIAPButton _iapButton;

        [SerializeField] private Currency.Currency _currency;
        [SerializeField] private IntReference _addAmount;

        [Header("UI")]
        [SerializeField] private TextMeshProUGUI _rewardText;
        
        private void OnEnable()
        {
            _rewardText.text = $"{_addAmount.Value}";
            _iapButton.onPurchaseComplete.AddListener(AddCurrency);
        }

        private void OnDisable()
        {
            _iapButton.onPurchaseComplete.RemoveListener(AddCurrency);
        }

        private async void AddCurrency(Product product)
        {
            _currency.Variable.Add(_addAmount);
        }
    }
}