using UnityEngine;
using UI;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event of type `UI.WindowsManager`. Inherits from `AtomEvent&lt;UI.WindowsManager&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-cherry")]
    [CreateAssetMenu(menuName = "Unity Atoms/Events/WindowsManager", fileName = "WindowsManagerEvent")]
    public sealed class WindowsManagerEvent : AtomEvent<UI.WindowsManager>
    {
    }
}
