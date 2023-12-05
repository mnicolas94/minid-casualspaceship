using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Score
{
    public class ScoreUpdater : MonoBehaviour
    {
        [SerializeField] private FloatReference _score;
        [SerializeField] private FloatReference _baseSpeed;
        [SerializeField] private FloatReference _speedToScoreMultiplier;

        private bool _isRunning;

        private void Start()
        {
            StartUpdating();
        }

        public void StartUpdating()
        {
            _isRunning = true;
        }

        public void StopUpdating()
        {
            _isRunning = false;
        }
        
        private void Update()
        {
            if (_isRunning)
            {
                _score.Value += _baseSpeed * _speedToScoreMultiplier * Time.deltaTime;
            }
        }
    }
}