using System;
using SaveSystem;
using UnityEngine;
using UnityEngine.Events;

namespace Missions
{
    public class MissionsPersistenceController : MonoBehaviour
    {
        [SerializeField] private MissionsSerializableList _currentMissions;

        [SerializeField] private UnityEvent _onLoaded;

        private async void Start()
        {
            await _currentMissions.LoadOrCreate();
            _onLoaded.Invoke();

            _currentMissions.Added += OnChanged;
            _currentMissions.Removed += OnChanged;
        }

        private void OnDestroy()
        {
            _currentMissions.Added -= OnChanged;
            _currentMissions.Removed -= OnChanged;
        }

        private async void OnChanged(IMission mission)
        {
            await _currentMissions.Save();
        }
    }
}