#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `UI.WindowsManager`. Inherits from `AtomDrawer&lt;WindowsManagerEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(WindowsManagerEvent))]
    public class WindowsManagerEventDrawer : AtomDrawer<WindowsManagerEvent> { }
}
#endif
