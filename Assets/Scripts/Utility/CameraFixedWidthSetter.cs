using System;
using UnityEngine;
using Utils.Attributes;

namespace Utility
{
    public class CameraFixedWidthSetter : MonoBehaviour
    {
        [SerializeField] private float _targetWidth;
        [SerializeField, AutoProperty(AutoPropertyMode.Scene)] private Camera _camera;

        private void Awake()
        {
            SetHeight();
        }

        [ContextMenu(nameof(SetHeight))]
        private void SetHeight()
        {
            var aspect = _camera.aspect;
            var targetHeight = _targetWidth / aspect;
            _camera.orthographicSize = targetHeight / 2;
        }
    }
}