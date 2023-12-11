using System;
using UnityEngine;
using Utils.Attributes;

namespace UI
{
    public class InteractionsDisabler : MonoBehaviour
    {
        [SerializeField, AutoProperty(AutoPropertyMode.Parent)] private CanvasGroup _canvasGroup;

        private void OnEnable()
        {
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }

        public void DisableInteractions()
        {
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }
    }
}