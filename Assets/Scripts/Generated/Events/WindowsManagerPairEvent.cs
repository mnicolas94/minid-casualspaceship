using UnityEngine;
using UI;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `WindowsManagerPair`. Inherits from `AtomEvent&lt;WindowsManagerPair&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/WindowsManagerPair", fileName = "WindowsManagerPairEvent")]
    public sealed class WindowsManagerPairEvent : AtomEvent<WindowsManagerPair>
    {
    }
}
