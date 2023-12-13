using System;
using SaveSystem;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Score
{
    public class RecordUpdater : MonoBehaviour
    {
        [SerializeField] private FloatReference _score;
        [SerializeField] private FloatVariable _record;

        private void OnEnable()
        {
            UpdateRecord();
        }

        private async void UpdateRecord()
        {
            if (_score.Value > _record.Value)
            {
                _record.Value = _score;
                await _record.Save();
            }
        }
    }
}