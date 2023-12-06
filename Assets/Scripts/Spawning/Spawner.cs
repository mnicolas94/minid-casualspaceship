using System;
using System.Collections.Generic;
using MackySoft.Choice;
using TriInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

namespace Spawning
{
    [Serializable]
    public class SpawnableWeight
    {
        public Spawnable Spawnable;
        public float Weight;
    }
    
    public class Spawner : MonoBehaviour
    {
        [SerializeField, TableList] private List<SpawnableWeight> _spawnablePrefabs;
        [SerializeField] private FloatReference _spawnCooldown;
        [SerializeField] private Transform _spawnPoint;

        private readonly Dictionary<Spawnable, ObjectPool<Spawnable>> _prefabsPool = new ();

        /// <summary>
        /// Trigger colliders inside spawnable area
        /// </summary>
        private int _triggersInside;
        private float _timeToSpawn;

        private bool CanSpawn => _triggersInside == 0 && Time.time >= _timeToSpawn;

        public void Clear()
        {
            foreach (var (prefab, pool) in _prefabsPool)
            {
                pool.Clear();
            }
        }
        
        private void Update()
        {
            if (CanSpawn)
            {
                Spawn();
            }
        }
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            _triggersInside++;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _triggersInside--;
            if (_triggersInside == 0)
            {
                StartCooldown();
            }
        }

        private void Spawn()
        {
            var weightedSelector = _spawnablePrefabs.ToWeightedSelector(item => item.Weight);
            var prefab = weightedSelector.SelectItemWithUnityRandom().Spawnable;
            GetPrefabsPool(prefab).Get();
            
            // avoid double spawns in same frame
            StartCooldown();
        }

        private ObjectPool<Spawnable> GetPrefabsPool(Spawnable prefab)
        {
            if (!_prefabsPool.TryGetValue(prefab, out var pool))
            {
                pool = new ObjectPool<Spawnable>(
                    () => OnPoolCreate(prefab),
                    OnPoolGet,
                    OnPoolRelease
                );
                _prefabsPool.Add(prefab, pool);
            }

            return pool;
        }

        private Spawnable OnPoolCreate(Spawnable prefab)
        {
            // spawn
            var instance = Instantiate(prefab, transform);
            
            // register on disable listener to release it on the pool
            instance.OnDisableEvent.AddListener(() => GetPrefabsPool(prefab).Release(instance));
            
            return instance;
        }

        private void OnPoolGet(Spawnable obj)
        {
            obj.gameObject.SetActive(true);
            
            // get spawn position
            var position = _spawnPoint.position;
            var range = obj.AllowedVerticalRange;
            var yPosition = Random.Range(range.x, range.y);
            position.y = yPosition;
            
            obj.transform.position = position;
        }

        private void OnPoolRelease(Spawnable obj)
        {
            
        }

        private void StartCooldown()
        {
            _timeToSpawn = Time.time + _spawnCooldown;
        }
    }
}