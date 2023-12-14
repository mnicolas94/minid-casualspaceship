using ModelView;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Currency.UI
{
    public class CurrencyCostView : ViewBaseBehaviour<CurrencyCost>
    {
        [SerializeField] private TextMeshProUGUI _costText;
        [SerializeField] private Image _currencyImage;
        
        public override bool CanRenderModel(CurrencyCost model)
        {
            return true;
        }

        public override void Initialize(CurrencyCost model)
        {
            UpdateView(model);
        }

        public override void UpdateView(CurrencyCost model)
        {
            _costText.text = $"{model.Cost.Value}";
            _currencyImage.sprite = model.Currency.Sprite;
        }
    }
}