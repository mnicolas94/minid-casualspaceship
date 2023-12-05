using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils.Behaviours;

namespace Spawning
{
    /// <summary>
    /// Disables itself if all children get disabled, and enable all of then on OnEnable
    /// </summary>
    public class SpawnableWithChildren : MonoBehaviour
    {
        private readonly Dictionary<GameObject, Vector3> _children = new ();

        private void Start()
        {
            // cache children and their initial positions
            for (int i = 0; i < transform.childCount; i++)
            {
                var child = transform.GetChild(i).gameObject;
                var events = child.AddComponent<BehaviourEvents>();
                events.OnDisableEvent.AddListener(OnChildDisabled);
                _children.Add(child, child.transform.localPosition);
            }
        }

        private void OnEnable()
        {
            // enable children and set initial position
            foreach (var (child, position) in _children)
            {
                child.SetActive(true);
                child.transform.localPosition = position;
            }
        }

        private void OnChildDisabled()
        {
            // check if all disabled
            var areAllDisabled = _children.All(child => !child.Key.activeSelf);
            if (areAllDisabled && gameObject.activeSelf)
            {
                gameObject.SetActive(false);
            }
        }
    }
}