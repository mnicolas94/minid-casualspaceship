using System;
using System.Threading;
using System.Threading.Tasks;
using Actions;
using AnimatorSequencerExtensions.Extensions;
using BrunoMikoski.AnimationSequencer;
using Character;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace GameEvents
{
    public class CharacterGameEventsListener : MonoBehaviour
    {
        [SerializeField] private VoidBaseEventReference _onStartEvent;
        [SerializeField] private VoidBaseEventReference _onEndEvent;
        [SerializeField] private VoidBaseEventReference _onContinueEvent;
        [SerializeField] private VoidBaseEventReference _onResetEvent;
        [SerializeField] private VoidBaseEventReference _onPauseEvent;
        [SerializeField] private VoidBaseEventReference _onUnpauseEvent;

        [SerializeField] private CharacterReferences _character;
        
        [Header("Actions")]
        [SerializeField] private Movement _movementAction;
        [SerializeField] private DashAction _dashAction;
        [SerializeField] private FloatReference _moveSpeedVariable;

        [Header("Inputs")]
        [SerializeField] private GameObject _inputs;

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
            _onPauseEvent.Event.Register(OnPause);
            _onUnpauseEvent.Event.Register(OnUnPause);
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
            _onPauseEvent.Event.Unregister(OnPause);
            _onUnpauseEvent.Event.Unregister(OnUnPause);
        }

        private async void OnStart()
        {
            // stop movement
            _movementAction.Stop();
            _movementAction.enabled = false;
 
            // disable inputs
            _inputs.SetActive(false);
            
            // enable trail
            _character.TrailParticleSystem.Play();
            
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
            
            // disable trail
            _character.TrailParticleSystem.Stop();
            
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
            // enable trail
            _character.TrailParticleSystem.Play();
            
            // await move to initial position
            _moveToInitialPositionAnimation.Play();
            await _moveToInitialPositionAnimation.PlayingSequence.AsyncWaitForCompletion(_cts.Token);
        }

        private async void OnPause()
        {
            // disable inputs
            _inputs.SetActive(false);
            
            // stop movement
            _movementAction.Stop();
            _movementAction.enabled = false;
            var oldSpeed = _moveSpeedVariable.Value;
            _moveSpeedVariable.Value = 0;
            
            // disable trail
            _character.TrailParticleSystem.Stop();
            
            // wait for any of the other events to trigger to set movement speed back to wat it was.
            await AsyncUtils.Utils.WaitFirstToFinish(_cts.Token, new (Func<CancellationToken, Task>, Action<Task>)[]
            {
                (ct => WaitForEvent(_onStartEvent, ct), null),
                (ct => WaitForEvent(_onEndEvent, ct), null),
                (ct => WaitForEvent(_onContinueEvent, ct), null),
                (ct => WaitForEvent(_onResetEvent, ct), null),
                (ct => WaitForEvent(_onUnpauseEvent, ct), null),
            });
            
            _moveSpeedVariable.Value = oldSpeed;
        }

        private void OnUnPause()
        {
            // enable inputs
            _inputs.SetActive(true);
            
            // enable movement
            _movementAction.enabled = true;
            
            // enable trail
            _character.TrailParticleSystem.Play();
        }

        private async Task WaitForEvent(VoidBaseEventReference @event, CancellationToken ct)
        {
            var isRaised = false;
            void OnEvent()
            {
                isRaised = true;
            }
            
            @event.Event.Register(OnEvent);

            while (!isRaised && !ct.IsCancellationRequested)
            {
                await Task.Yield();
            }
            
            @event.Event.Unregister(OnEvent);
        }
    }
}
