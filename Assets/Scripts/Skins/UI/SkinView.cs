using ModelView;
using TNRD;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.UI;
using Unlockables;

namespace Skins.UI
{
    public class SkinView : ViewBaseBehaviour<SkinData>
    {
        [SerializeField] private SerializableInterface<IUnlockablesStorage<SkinData>> _storage;

        [SerializeField] private LocalizeStringEvent _nameText;
        [SerializeField] private Image _skinImage;

        [SerializeField] private Button _equipButton;
        [SerializeField] private Button _payCostButton;
        
        public override bool CanRenderModel(SkinData model)
        {
            return true;
        }

        public override void Initialize(SkinData model)
        {
            _equipButton.gameObject.SetActive(false);
            _payCostButton.gameObject.SetActive(false);
            
            UpdateView(model);
        }

        public override async void UpdateView(SkinData model)
        {
            _nameText.StringReference = model.SkinName;
            _skinImage.sprite = model.PreviewSprite;
        }
    }
}