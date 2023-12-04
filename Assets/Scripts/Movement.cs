using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float _maxSpeed;
        [SerializeField] private float _lerpSpeed;
        [SerializeField] private Camera _camera;

        private float _targetSpeed;
        private float _currentSpeed;

        public void Move(float dir)
        {
            dir = Mathf.Clamp(dir, -1, 1);
            _targetSpeed = dir * _maxSpeed;
        }
        
        public void MoveUp()
        {
            Move(1);
        }

        public void MoveDown()
        {
            Move(-1);
        }

        private void FixedUpdate()
        {
            // accelerate
            _currentSpeed = Mathf.Lerp(_currentSpeed, _targetSpeed, _lerpSpeed);

            // calculate position
            var tr = transform;
            var position = tr.position;
            position.y += _currentSpeed * Time.fixedDeltaTime;
            
            // check limits
            var screenHeight = _camera.orthographicSize;
            var cameraPosition = _camera.transform.position;
            var topLimit = cameraPosition.y + screenHeight;
            var botLimit = cameraPosition.y - screenHeight;
            
            if (position.y > topLimit)
            {
                var offset = position.y - topLimit;
                position.y = botLimit + offset;
            }
            
            if (position.y < botLimit)
            {
                var offset = position.y - botLimit;
                position.y = topLimit + offset;
            }
            
            // update position
            tr.position = position;
        }
    }
}