using System.Threading;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace GameEvents
{
    public class EnvironmentGameEventsListener : MonoBehaviour
    {
        [SerializeField] private VoidBaseEventReference _onStartEvent;
        [SerializeField] private VoidBaseEventReference _onEndEvent;
        [SerializeField] private VoidBaseEventReference _onContinueEvent;
        [SerializeField] private VoidBaseEventReference _onResetEvent;

        [SerializeField] private GameObject _spawner;
        [SerializeField] private GameObject _scoreUpdater;
        [SerializeField] private FloatReference _score;

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

        private void OnStart()
        {
            // enable spawner and score updater
            _spawner.SetActive(true);
            _scoreUpdater.SetActive(true);
        }

        private void OnEnd()
        {
            // enable spawner and score updater
            _spawner.SetActive(false);
            _scoreUpdater.SetActive(false);
        }
        
        private void OnContinue()
        {
            // same as on start
            OnStart();
        }

        private async void OnReset()
        {
            // reset score
            _score.Value = 0;
        }
    }
}