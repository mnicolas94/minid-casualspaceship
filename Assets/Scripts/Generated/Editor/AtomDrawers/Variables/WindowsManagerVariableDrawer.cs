#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable property drawer of type `UI.WindowsManager`. Inherits from `AtomDrawer&lt;WindowsManagerVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(WindowsManagerVariable))]
    public class WindowsManagerVariableDrawer : VariableDrawer<WindowsManagerVariable> { }
}
#endif
