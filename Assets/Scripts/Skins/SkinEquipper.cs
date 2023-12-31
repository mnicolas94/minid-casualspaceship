﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Character;
using DefaultNamespace.AddressablesExtensions;
using SaveSystem;
using UnityEngine;
using Utils;

namespace Skins
{
    public class SkinEquipper : MonoBehaviour
    {
        [SerializeField] private CharacterReferences _character;
        [SerializeField] private PersistedEquippedSkin _persistence;
        [SerializeField] private AddressableSkinData _defaultSkinSpaceship;
        [SerializeField] private AddressableSkinData _defaultSkinTrail;

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
            var spaceshipSkin = _persistence.SpaceshipSkin ?? _defaultSkinSpaceship;
            var trailSkin = _persistence.TrailSkin ?? _defaultSkinTrail;
            EquipSkin(spaceshipSkin);
            EquipSkin(trailSkin);
        }

        public async Task<bool> IsEquipped(AddressableSkinData skin)
        {
            var skinData = await skin.GetOrLoadAssetAsync();
            var equippedSkin = skinData.SkinType == SkinType.Spaceship
                ? _persistence.SpaceshipSkin
                : _persistence.TrailSkin;
            return skin.Equals(equippedSkin);
        }

        public async void EquipSkin(AddressableSkinData addressableSkin)
        {
            if (addressableSkin == null)
            {
                return;
            }
            
            var skin = await addressableSkin.GetOrLoadAssetAsync();
            
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
                _persistence.SpaceshipSkin = addressableSkin;
            }
            else
            {
                _persistence.TrailSkin = addressableSkin;
            }

            await _persistence.Save();
        }
    }
}