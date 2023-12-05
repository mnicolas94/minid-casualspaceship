using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Enemies
{
    public class UniformLineMovement : MonoBehaviour
    {
        [SerializeField] private FloatReference _speed;
        [SerializeField] private Vector2 _dir;

        private void FixedUpdate()
        {
            var displacement = _dir.normalized * (_speed.Value * Time.fixedDeltaTime);
            var position = transform.position;
            position += (Vector3) displacement;
            transform.position = position;
        }
    }
}