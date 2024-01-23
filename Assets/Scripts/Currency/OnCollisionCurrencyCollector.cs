using System;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;
using Utils.Extensions;

namespace Currency
{
    public class OnCollisionCurrencyCollector : MonoBehaviour
    {
        [SerializeField] private IntReference _toCollect;
        [SerializeField] private IntReference _currencyCollectedCount;
        [SerializeField] private LayerMask _playerLayer;

        [SerializeField] private UnityEvent _onCollected;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_playerLayer.IsLayerInMask(col.gameObject.layer))
            {
                _currencyCollectedCount.Value += _toCollect;
                
                _onCollected.Invoke();
                
                // disable
                gameObject.SetActive(false);
            }
        }
    }
}