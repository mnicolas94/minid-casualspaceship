using ModelView;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

namespace Skins.UI
{
    public class SkinView : ViewBaseBehaviour<SkinData>
    {
        [SerializeField] private LocalizeStringEvent _nameText;
        [SerializeField] private Image _skinImage;
        
        public override bool CanRenderModel(SkinData model)
        {
            return true;
        }

        public override void Initialize(SkinData model)
        {
            UpdateView(model);
        }

        public override void UpdateView(SkinData model)
        {
            _nameText.StringReference = model.SkinName;
            _skinImage.sprite = model.PreviewSprite;
        }
    }
}