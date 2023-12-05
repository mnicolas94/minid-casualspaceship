using System;
using UnityEngine;

namespace Enemies
{
    /// <summary>
    /// Disables enemies that go far beyond the screen's left  edge
    /// </summary>
    public class EnemiesGarbageCollector : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            col.gameObject.SetActive(false);
        }
    }
}