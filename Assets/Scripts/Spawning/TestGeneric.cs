using GenericUnityObjects;
using UnityEngine;

namespace Spawning
{
    // [CreateAssetMenu(fileName = "FILENAME", menuName = "MENUNAME", order = 0)]
    [CreateGenericAssetMenu]
    public class TestGeneric<T> : GenericScriptableObject
    {
        [SerializeField] private T _generic;
    }
}