#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Constant property drawer of type `UI.WindowsManager`. Inherits from `AtomDrawer&lt;WindowsManagerConstant&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(WindowsManagerConstant))]
    public class WindowsManagerConstantDrawer : VariableDrawer<WindowsManagerConstant> { }
}
#endif
