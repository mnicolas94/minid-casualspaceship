#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using UI;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `WindowsManagerPair`. Inherits from `AtomEventEditor&lt;WindowsManagerPair, WindowsManagerPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(WindowsManagerPairEvent))]
    public sealed class WindowsManagerPairEventEditor : AtomEventEditor<WindowsManagerPair, WindowsManagerPairEvent> { }
}
#endif
