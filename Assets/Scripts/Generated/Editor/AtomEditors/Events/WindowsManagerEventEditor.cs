#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using UI;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `UI.WindowsManager`. Inherits from `AtomEventEditor&lt;UI.WindowsManager, WindowsManagerEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(WindowsManagerEvent))]
    public sealed class WindowsManagerEventEditor : AtomEventEditor<UI.WindowsManager, WindowsManagerEvent> { }
}
#endif
