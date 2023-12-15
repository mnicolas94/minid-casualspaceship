using System;
using System.Threading;
using ModelView;
using UnityAtoms.BaseAtoms;
using UnityEngine;
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

        private CancellationTokenSource _cts;

        private bool _unlocked;
        public bool Unlocked
        {
            set
            {
                if (_unlocked != value)
                {
                    _unlocked = value;
                    Initialize(_model);
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
            _equipButton.gameObject.SetActive(false);
            _payCostButton.gameObject.SetActive(false);
            _costView.gameObject.SetActive(false);
 
            UpdateView(model);
        }

        public override void UpdateView(SkinData model)
        {
            // _nameText.StringReference = model.SkinName;
            _skinImage.sprite = model.PreviewSprite;

            if (_unlocked)
            {
                _equipButton.gameObject.SetActive(true);
            }
            else
            {
                _payCostButton.gameObject.SetActive(true);
                _costView.gameObject.SetActive(true);
                _costView.Initialize(model.UnlockCost);
            }
        }
        
        private void OnEquipButtonClick()
        {
            _equipButton.interactable = false;
            
            _equipEvent.Raise(_model);
            
            _equipButton.interactable = true;
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