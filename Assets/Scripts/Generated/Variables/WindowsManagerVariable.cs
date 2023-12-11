using UnityEngine;
using System;
using UI;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Variable of type `UI.WindowsManager`. Inherits from `AtomVariable&lt;UI.WindowsManager, WindowsManagerPair, WindowsManagerEvent, WindowsManagerPairEvent, WindowsManagerWindowsManagerFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/WindowsManager", fileName = "WindowsManagerVariable")]
    public sealed class WindowsManagerVariable : AtomVariable<UI.WindowsManager, WindowsManagerPair, WindowsManagerEvent, WindowsManagerPairEvent, WindowsManagerWindowsManagerFunction>
    {
        protected override bool ValueEquals(UI.WindowsManager other)
        {
            return other == _value;
        }
    }
}
