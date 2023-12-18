using UnityEngine;
using Skins;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `Skins.SkinData`. Inherits from `AtomEvent&lt;Skins.SkinData&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/SkinData", fileName = "SkinDataEvent")]
    public sealed class SkinDataEvent : AtomEvent<Skins.SkinData>
    {
    }
}
