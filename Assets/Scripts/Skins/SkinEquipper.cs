using System;
using System.Threading;
using Character;
using SaveSystem;
using UnityEngine;
using Utils;

namespace Skins
{
    public class SkinEquipper : MonoBehaviour
    {
        [SerializeField] private CharacterReferences _character;
        [SerializeField] private PersistedEquippedSkin _persistence;

        private readonly PrefabsToInstanceMap _spaceshipPrefabsInstances = new();
        private readonly PrefabsToInstanceMap _trailPrefabsInstances = new();

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
        
        private async void Start()
        {
            await SaveLoadBroadcaster.Instance.WaitToBeLoadedOrAlreadyLoadedAsync(_persistence, _cts.Token);
            EquipSkin(_persistence.SpaceshipSkin);
            EquipSkin(_persistence.TrailSkin);
        }

        public async void EquipSkin(SkinData skin)
        {
            if (skin == null)
            {
                return;
            }
            
            var isSpaceship = skin.SkinType == SkinType.Spaceship;
            if (isSpaceship)
            {
                _character.SpaceshipSprite.sprite = skin.PreviewSprite;
            }

            // instantiate prefab if not null
            if (skin.Prefab != null)
            {
                var instancesMap = isSpaceship ? _spaceshipPrefabsInstances : _trailPrefabsInstances;
                // disable all
                instancesMap.GetAllInstancesOfType<GameObject>().ForEach(instance => instance.SetActive(false));
                var instance = instancesMap.GetOrCreateInstance<GameObject>(skin.Prefab);
                instance.SetActive(true);
                
                // set parent
                var parent = isSpaceship ? _character.SpaceshipParent : _character.TrailParent;
                instance.transform.SetParent(parent, false);

                if (!isSpaceship)
                {
                    _character.TrailParticleSystem = instance.GetComponent<ParticleSystem>();
                }
            }
            
            // persist
            if (isSpaceship)
            {
                _persistence.SpaceshipSkin = skin;
            }
            else
            {
                _persistence.TrailSkin = skin;
            }

            await _persistence.Save();
        }
    }
}