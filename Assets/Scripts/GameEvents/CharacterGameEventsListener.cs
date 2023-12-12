using System;
using System.Threading;
using Actions;
using AnimatorSequencerExtensions.Extensions;
using BrunoMikoski.AnimationSequencer;
using Input;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Void = UnityAtoms.Void;

namespace GameEvents
{
    public class CharacterGameEventsListener : MonoBehaviour
    {
        [SerializeField] private VoidBaseEventReference _onStartEvent;
        [SerializeField] private VoidBaseEventReference _onEndEvent;
        [SerializeField] private VoidBaseEventReference _onContinueEvent;
        [SerializeField] private VoidBaseEventReference _onResetEvent;

        [Header("Actions")]
        [SerializeField] private Movement _movementAction;
        [SerializeField] private DashAction _dashAction;

        [Header("Inputs")]
        [SerializeField] private GameObject _inputs;
        [SerializeField] private MoveInput _moveInput;
        [SerializeField] private DashInput _dashInput;

        [Header("Animations")]
        [SerializeField] private AnimationSequencerController _moveToInitialPositionAnimation;
        [SerializeField] private AnimationSequencerController _deadAnimation;

        private CancellationTokenSource _cts;

        private void OnEnable()
        {
            _cts = new CancellationTokenSource();
            
            _onStartEvent.Event.Register(OnStart);
            _onEndEvent.Event.Register(OnEnd);
            _onContinueEvent.Event.Register(OnContinue);
            _onResetEvent.Event.Register(OnReset);
        }

        private void OnDisable()
        {
            if (!_cts.IsCancellationRequested)
            {
                _cts.Cancel();
            }

            _cts.Dispose();
            _cts = null;
            
            _onStartEvent.Event.Unregister(OnStart);
            _onEndEvent.Event.Unregister(OnEnd);
            _onContinueEvent.Event.Unregister(OnContinue);
            _onResetEvent.Event.Unregister(OnReset);
        }

        private async void OnStart()
        {
            // stop movement
            _movementAction.Stop();
            _movementAction.enabled = false;
 
            // disable inputs
            _inputs.SetActive(false);

            // await move to initial position
            _moveToInitialPositionAnimation.Play();
            await _moveToInitialPositionAnimation.PlayingSequence.AsyncWaitForCompletion(_cts.Token);

            // enable inputs
            _inputs.SetActive(true);
            
            // enable movement
            _movementAction.enabled = true;
        }

        private async void OnEnd()
        {
            // disable inputs
            _inputs.SetActive(false);
            
            // stop movement
            _movementAction.Stop();
            _movementAction.enabled = false;
            
            // await death animation
            _deadAnimation.Play();
            await _deadAnimation.PlayingSequence.AsyncWaitForCompletion(_cts.Token);
        }
        
        private void OnContinue()
        {
            // same as on start
            OnStart();
        }

        private async void OnReset()
        {
            // await move to initial position
            _moveToInitialPositionAnimation.Play();
            await _moveToInitialPositionAnimation.PlayingSequence.AsyncWaitForCompletion(_cts.Token);
        }
    }
}