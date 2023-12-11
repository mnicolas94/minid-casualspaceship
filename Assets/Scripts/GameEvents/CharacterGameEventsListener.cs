using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Void = UnityAtoms.Void;

namespace GameEvents
{
    public class CharacterGameEventsListener : MonoBehaviour
    {
        [SerializeField] private VoidBaseEventReference _onStartEvent;
        [SerializeField] private VoidBaseEventReference _onEndEvent;
        [SerializeField] private VoidBaseEventReference _onResetEvent;
        
        

        private void OnEnable()
        {
            _onStartEvent.Event.Register(OnStart);
            _onEndEvent.Event.Register(OnEnd);
            _onResetEvent.Event.Register(OnReset);
        }
        
        private void OnDisable()
        {
            _onStartEvent.Event.Unregister(OnStart);
            _onEndEvent.Event.Unregister(OnEnd);
            _onResetEvent.Event.Unregister(OnReset);
        }

        private void OnStart()
        {
            // disable inputs
            
            // await move to initial position
            
            // enable inputs
            // enable spawner
            // enable score updater
        }

        private void OnEnd()
        {
            // disable inputs
            // disable spawner
            // disable score updater
            
            // await death animation
        }

        private void OnReset()
        {
            // await move to initial position
            // reset score
        }
    }
}