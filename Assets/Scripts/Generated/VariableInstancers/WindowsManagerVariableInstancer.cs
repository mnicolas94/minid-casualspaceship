using UnityEngine;
using UnityAtoms.BaseAtoms;
using UI;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Variable Instancer of type `UI.WindowsManager`. Inherits from `AtomVariableInstancer&lt;WindowsManagerVariable, WindowsManagerPair, UI.WindowsManager, WindowsManagerEvent, WindowsManagerPairEvent, WindowsManagerWindowsManagerFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-hotpink")]
    [AddComponentMenu("Unity Atoms/Variable Instancers/WindowsManager Variable Instancer")]
    public class WindowsManagerVariableInstancer : AtomVariableInstancer<
        WindowsManagerVariable,
        WindowsManagerPair,
        UI.WindowsManager,
        WindowsManagerEvent,
        WindowsManagerPairEvent,
        WindowsManagerWindowsManagerFunction>
    { }
}
