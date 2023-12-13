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
        [SerializeField] private TextMeshProUGUI _costText;
        [SerializeField] private string _costFormat;
        
        [SerializeField] private VoidBaseEventReference _continueGameEvent;
        
        [SerializeField] private IntVariable _hardCurrency;
        [SerializeField] private IntReference _currencyCost;

        private void Start()
        {
            UpdateUi();
            
            _continueButton.onClick.AddListener(PayCostAndContinue);
        }

        private void UpdateUi()
        {
            _costText.text = string.Format(_costFormat, $"{_currencyCost.Value}");
        }

        private async void PayCostAndContinue()
        {
            _canvasGroup.interactable = false;
            
            var canAfford = _hardCurrency.Value >= _currencyCost;

            if (canAfford)
            {
                _hardCurrency.Value -= _currencyCost;
                await _hardCurrency.Save();
                
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