using UnityEngine;
using Skins;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `SkinDataPair`. Inherits from `AtomEvent&lt;SkinDataPair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/SkinDataPair", fileName = "SkinDataPairEvent")]
    public sealed class SkinDataPairEvent : AtomEvent<SkinDataPair>
    {
    }
}
