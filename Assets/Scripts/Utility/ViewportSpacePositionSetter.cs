using System;
using UnityEngine;
using Utils.Attributes;

namespace Utility
{
    public class ViewportSpacePositionSetter : MonoBehaviour
    {
        [SerializeField, AutoProperty(AutoPropertyMode.Scene)] private Camera _camera;
        [SerializeField, AutoProperty] private Transform _target;
        [SerializeField] private Vector2 _viewportPosition;
        [SerializeField] private Vector3 _worldOffset;
        
        private void Awake()
        {
            SetPosition();
        }

        [ContextMenu(nameof(SetPosition))]
        private void SetPosition()
        {
            var worldPoint = _camera.ViewportToWorldPoint(_viewportPosition);
            worldPoint.z = _target.position.z;
            worldPoint += _worldOffset;
            _target.position = worldPoint;
        }
    }
}