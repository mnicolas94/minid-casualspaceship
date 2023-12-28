using System;
using SaveSystem.Attributes;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Missions
{
    [Serializable]
    public class MissionCollectXCoins : BaseMission
    {
        [SerializeField, DoNotPersist] private Currency.Currency _currency;
        [SerializeField, DoNotPersist] private float _goal;
        
        [SerializeField] private int _currentCollected;
        
        public override void Initialize()
        {
            _currentCollected = 0;
        }

        public override void StartMission()
        {
            _currency.CurrentInGame.ChangedWithHistory.Register(OnCurrencyCollected);
        }

        public override void EndMission()
        {
            _currency.CurrentInGame.ChangedWithHistory.Unregister(OnCurrencyCollected);
        }

        private void OnCurrencyCollected(IntPair tuple)
        {
            var (oldValue, newValue) = tuple;
            var difference = newValue - oldValue;
            var didIncrease = difference > 0;
            if (didIncrease)
            {
                _currentCollected += difference;
                if (_currentCollected >= _goal)
                {
                    OnCompleted?.Invoke();
                }
            }
        }
    }
}