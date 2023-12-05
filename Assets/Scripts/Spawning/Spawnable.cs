using System;
using UnityEngine;
using UnityEngine.Events;

namespace Spawning
{
    public class Spawnable : MonoBehaviour
    {
        [SerializeField] private Vector2 _allowedVerticalRange;
        [SerializeField] private UnityEvent _onDisable;

        public Vector2 AllowedVerticalRange => _allowedVerticalRange;

        public UnityEvent OnDisableEvent => _onDisable;

        private void OnDisable()
        {
            _onDisable.Invoke();
        }
    }
}