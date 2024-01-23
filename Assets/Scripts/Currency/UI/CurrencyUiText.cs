using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.UI;

namespace Currency.UI
{
    public enum CurrencyContext
    {
        Total,
        InGame,
    }
    
    public class CurrencyUiText : MonoBehaviour
    {
        [SerializeField] private Currency _currency;
        [SerializeField] private CurrencyContext _currencyContext;
        [SerializeField] private Image _currencyIcon;
        [SerializeField] private TextMeshProUGUI _text;

        private IntVariable Variable =>
            _currencyContext == CurrencyContext.Total ? _currency.Variable : _currency.CurrentInGame;

        private void OnEnable()
        {
            UpdateUi();
            Variable.Changed.Register(UpdateText);
        }

        private void OnDisable()
        {
            Variable.Changed.Unregister(UpdateText);
        }

        private void UpdateUi()
        {
            _currencyIcon.sprite = _currency.Sprite;
            UpdateText();
        }

        private void UpdateText()
        {
            _text.text = Variable.Value.ToString();
        }
    }
}