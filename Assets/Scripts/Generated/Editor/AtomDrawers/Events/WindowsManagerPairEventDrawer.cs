#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `WindowsManagerPair`. Inherits from `AtomDrawer&lt;WindowsManagerPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(WindowsManagerPairEvent))]
    public class WindowsManagerPairEventDrawer : AtomDrawer<WindowsManagerPairEvent> { }
}
#endif
