using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class MoveInput : MonoBehaviour
    {
        [SerializeField] private Movement _movement;
        [SerializeField] private InputActionReference _inputActionReference;

        private InputAction _inputAction;

        private void Awake()
        {
            _inputAction = _inputActionReference.action;
        }

        private void OnEnable()
        {
            _inputAction.Enable();
        }

        private void OnDisable()
        {
            _inputAction.Disable();
        }

        private void Update()
        {
            var inputValue = _inputAction.ReadValue<float>();

            var pressed = inputValue > 0.5f;

            if (pressed)
            {
                _movement.MoveUp();
            }
            else
            {
                _movement.MoveDown();
            }
        }
    }
}