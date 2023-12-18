using System;
using System.Threading;
using System.Threading.Tasks;
using ModelView;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

namespace Skins.UI
{
    public class SkinView : ViewBaseBehaviour<SkinData>
    {
        [SerializeField] private SkinDataEvent _equipEvent;
        [SerializeField] private SkinDataEvent _costPaidEvent;
        
        [SerializeField] private LocalizeStringEvent _nameText;
        [SerializeField] private Image _skinImage;

        [SerializeField] private Button _equipButton;
        [SerializeField] private Button _payCostButton;
        [SerializeField] private MultiViewDelegate _costView;
        [SerializeField] private LocalizeStringEvent _equippedText;
        [SerializeField] private LocalizedString _equippedString;
        [SerializeField] private LocalizedString _nonEquippedString;

        private CancellationTokenSource _cts;

        private bool _unlocked;
        public bool Unlocked
        {
            set
            {
                if (_unlocked != value)
                {
                    _unlocked = value;
                    UpdateUnlockedState();
                }
            }
        }
        
        private bool _equipped;
        public bool Equipped
        {
            set
            {
                if (_equipped != value)
                {
                    _equipped = value;
                    UpdateEquippedState();
                }
            }
        }

        private void Start()
        {
            _equipButton.onClick.AddListener(OnEquipButtonClick);
            _payCostButton.onClick.AddListener(OnPayCostButtonClick);
        }

        private void OnEnable()
        {
            _cts = new CancellationTokenSource();
        }

        private void OnDisable()
        {
            if (!_cts.IsCancellationRequested)
            {
                _cts.Cancel();
            }

            _cts.Dispose();
            _cts = null;
        }
        
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
            // _nameText.StringReference = model.SkinName;
            _skinImage.sprite = model.PreviewSprite;

            UpdateUnlockedState();
            UpdateEquippedState();
        }

        private void UpdateUnlockedState()
        {
            _equipButton.gameObject.SetActive(_unlocked);
            _payCostButton.gameObject.SetActive(!_unlocked);
            _costView.gameObject.SetActive(!_unlocked);
            if (!_unlocked)
            {
                _costView.Initialize(_model.UnlockCost);
            }
        }

        private void UpdateEquippedState()
        {
            _equipButton.interactable = !_equipped;
            _equippedText.StringReference = _equipped ? _equippedString : _nonEquippedString;
        }
        
        private void OnEquipButtonClick()
        {
            _equipEvent.Raise(_model);
        }

        private async void OnPayCostButtonClick()
        {
            _payCostButton.interactable = false;

            var ct = _cts.Token;
            var paid = await _model.UnlockCost.PayCost(ct);
            if (paid)
            {
                _costPaidEvent.Raise(_model);
            }
            
            _payCostButton.interactable = true;
        }
    }
}