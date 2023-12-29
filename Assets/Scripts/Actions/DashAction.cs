using System.Threading;
using System.Threading.Tasks;
using BrunoMikoski.AnimationSequencer;
using DG.Tweening;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Actions
{
    public class DashAction : MonoBehaviour
    {
        [SerializeField] private FloatReference _distance;
        [SerializeField] private FloatReference _baseHorizontalSpeed;
        [SerializeField] private FloatReference _recoverPositionSpeedScale;
        [SerializeField] private FloatReference _cooldown;

        [SerializeField] private Collider2D _collider;

        [SerializeField] private AnimationSequencerController _launchAnimation;
        [SerializeField] private AnimationSequencerController _arriveAnimation;

        private float _nextTimeAvailable;
        private bool _isCurrentlyDashing;
        private float _horizontalPositionBeforeDash;

        private bool CanDash => enabled && Time.time >= _nextTimeAvailable && !_isCurrentlyDashing;

        private CancellationTokenSource _cts;

        private void OnEnable()
        {
            _cts = new CancellationTokenSource();
        }

        private void OnDisable()
        {
            if (!_cts.IsCancellationRequested)
            {
                _cts.Cancel();
            }

            _cts.Dispose();
            _cts = null;
        }
        
        public async void Dash()
        {
            if (CanDash)
            {
                _isCurrentlyDashing = true;
                
                // play teleport launch effect async
                _launchAnimation.Play();
                await _launchAnimation.PlayingSequence.AsyncWaitForCompletion();
                // disable collider
                _collider.enabled = false;
                
                // store current horizontal position and move to dash position
                var selfTransform = transform;
                var position = selfTransform.position;
                _horizontalPositionBeforeDash = position.x;
                position.x += _distance;
                selfTransform.position = position;
                
                // play teleport arrive effect async
                _arriveAnimation.Play();
                await _arriveAnimation.PlayingSequence.AsyncWaitForCompletion();
                _collider.enabled = true;

                // start recovering horizontal position
                var ct = _cts.Token;
                var time = Time.time;
                while (position.x > _horizontalPositionBeforeDash && !ct.IsCancellationRequested)
                {
                    var delta = Time.time - time;
                    time = Time.time;
                    position = selfTransform.position;
                    var recoverSpeed = _baseHorizontalSpeed * _recoverPositionSpeedScale;
                    position.x -= recoverSpeed * delta;
                    selfTransform.position = position;
                    
                    await Task.Yield();
                }

                if (!ct.IsCancellationRequested)
                {
                    position.x = _horizontalPositionBeforeDash;
                    selfTransform.position = position;
                }
                
                // calculate next time available based on cooldown
                _nextTimeAvailable = Time.time + _cooldown;
                
                _isCurrentlyDashing = false;
            }
        }
    }
}