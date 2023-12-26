using System;
using SaveSystem;
using SaveSystem.Attributes;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Utility
{
    [CreateAssetMenu(menuName = "Persistence/Int variable", fileName = "IntVariable", order = 0)]
    public class IntVariablePersistent : ScriptableObject, IPersistentCallbackReceiver
    {
        [SerializeField] private int _value;
        [SerializeField, DoNotPersist] private IntVariable _variable;
        [SerializeField, DoNotPersist] private bool _autoSave;

        private void OnEnable()
        {
            if (_autoSave)
            {
                _variable.Changed.Register(OnVariableChange);
            }
        }

        private void OnDisable()
        {
            if (_autoSave)
            {
                _variable.Changed.Unregister(OnVariableChange);
            }
        }
        
        private async void OnVariableChange()
        {
            if (_autoSave)
            {
                await this.Save();
            }
        }

        public void OnBeforeSave(AssetGuidsDatabase guidsDatabase)
        {
            _value = _variable.Value;
        }

        public void OnAfterSave()
        {
            
        }

        public void OnBeforeLoad()
        {
            
        }

        public void OnAfterLoad(AssetGuidsDatabase guidsDatabase)
        {
            _variable.Value = _value;
        }
    }
}