using System;
using UnityEngine;
using Utils.Extensions;

namespace Enemies
{
    public class CollisionEnemy : MonoBehaviour
    {
        [SerializeField] private LayerMask _playerLayer;
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_playerLayer.IsLayerInMask(col.gameObject.layer))
            {
                Debug.Log("Enemy collision");
            }
        }
    }
}