using System;
using SaveSystem;
using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ContinueButtonController : MonoBehaviour
    {
        [SerializeField] private Button _continueButton;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Image _currencyIcon;
        [SerializeField] private TextMeshProUGUI _costText;
        [SerializeField] private string _costFormat;
        
        [SerializeField] private VoidBaseEventReference _continueGameEvent;
        
        [SerializeField] private Currency.Currency _currency;
        [SerializeField] private IntReference _currencyCost;

        private void Start()
        {
            UpdateUi();
            
            _continueButton.onClick.AddListener(PayCostAndContinue);
        }

        private void UpdateUi()
        {
            _currencyIcon.sprite = _currency.Sprite;
            _costText.text = string.Format(_costFormat, $"{_currencyCost.Value}");
        }

        private async void PayCostAndContinue()
        {
            _canvasGroup.interactable = false;
            
            var canAfford = _currency.Variable.Value >= _currencyCost;

            if (canAfford)
            {
                _currency.Variable.Value -= _currencyCost;
                
                _continueGameEvent.Event.Raise();
            }
            else
            {
                // TODO show store to buy currency
            }
            
            _canvasGroup.interactable = true;
        }
    }
}