using UnityEditor;
using UnityAtoms.Editor;
using UI;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable Inspector of type `UI.WindowsManager`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(WindowsManagerVariable))]
    public sealed class WindowsManagerVariableEditor : AtomVariableEditor<UI.WindowsManager, WindowsManagerPair> { }
}
