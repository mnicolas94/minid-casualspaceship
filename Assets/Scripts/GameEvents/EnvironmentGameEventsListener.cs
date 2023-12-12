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
        
        [Header("Score")]
        [SerializeField] private GameObject _scoreUpdater;
        [SerializeField] private FloatReference _score;
        
        [Header("Currencies")]
        [SerializeField] private IntReference _currentSoftCurrency;
        [SerializeField] private IntReference _currentHardCurrency;

        private CancellationTokenSource _cts;

        private void OnEnable()
        {
            _cts = new CancellationTokenSource();
            
            _onStartEvent.Event.Register(StartGame);
            _onEndEvent.Event.Register(EndGame);
            _onContinueEvent.Event.Register(ContinueGame);
            _onResetEvent.Event.Register(ResetGame);
        }

        private void OnDisable()
        {
            if (!_cts.IsCancellationRequested)
            {
                _cts.Cancel();
            }

            _cts.Dispose();
            _cts = null;
            
            _onStartEvent.Event.Unregister(StartGame);
            _onEndEvent.Event.Unregister(EndGame);
            _onContinueEvent.Event.Unregister(ContinueGame);
            _onResetEvent.Event.Unregister(ResetGame);
        }

        private void StartGame()
        {
            ResetGame();
            ContinueGame();
        }

        private void EndGame()
        {
            // enable spawner and score updater
            _spawner.SetActive(false);
            _scoreUpdater.SetActive(false);
        }
        
        private void ContinueGame()
        {
            // enable spawner and score updater
            _spawner.SetActive(true);
            _scoreUpdater.SetActive(true);
        }

        private void ResetGame()
        {
            // reset score
            _score.Value = 0;
            _currentSoftCurrency.Value = 0;
            _currentHardCurrency.Value = 0;
        }
    }
}