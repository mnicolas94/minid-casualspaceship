using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using Utils.Extensions;

namespace Enemies
{
    public class CollisionWithEnemy : MonoBehaviour
    {
        [SerializeField] private LayerMask _mask;
        [SerializeField] private GameObjectValueList _list;

        [SerializeField] private UnityEvent<Collider2D> _onTriggerEnter;
        [SerializeField] private UnityEvent<Collider2D> _onTriggerExit;

        private bool CanTriggerWithObject(GameObject go)
        {
            return _list.Contains(go) && _mask.IsLayerInMask(go.layer);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            var go = other.gameObject;
            if (CanTriggerWithObject(go))
            {
                _onTriggerEnter.Invoke(other);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var go = other.gameObject;
            if (CanTriggerWithObject(go))
            {
                _onTriggerExit.Invoke(other);
            }
        }
    }
}