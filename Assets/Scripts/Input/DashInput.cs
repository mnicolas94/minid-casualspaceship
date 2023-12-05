using Actions;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class DashInput : MonoBehaviour
    {
        [SerializeField] private DashAction _dash;
        [SerializeField] private InputActionReference _inputActionReference;

        private InputAction _inputAction;

        private void Awake()
        {
            _inputAction = _inputActionReference.action;
        }

        private void OnEnable()
        {
            _inputAction.Enable();
            _inputAction.performed += Dash;
        }

        private void OnDisable()
        {
            _inputAction.Disable();
            _inputAction.performed -= Dash;
        }

        private void Dash(InputAction.CallbackContext ctx)
        {
            _dash.Dash();
        }
    }
}