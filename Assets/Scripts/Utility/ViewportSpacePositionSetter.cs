using System;
using UnityEngine;

namespace Utility
{
    public class ViewportSpacePositionSetter : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _target;
        [SerializeField] private Vector2 _position;
        
        private void Awake()
        {
            SetPosition();
        }

        [ContextMenu(nameof(SetPosition))]
        private void SetPosition()
        {
            var worldPoint = _camera.ViewportToWorldPoint(_position);
            worldPoint.z = _target.position.z;
            _target.position = worldPoint;
        }
    }
}