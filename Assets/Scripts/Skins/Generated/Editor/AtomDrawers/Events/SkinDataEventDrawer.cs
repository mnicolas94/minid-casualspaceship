#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `Skins.SkinData`. Inherits from `AtomDrawer&lt;SkinDataEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(SkinDataEvent))]
    public class SkinDataEventDrawer : AtomDrawer<SkinDataEvent> { }
}
#endif
