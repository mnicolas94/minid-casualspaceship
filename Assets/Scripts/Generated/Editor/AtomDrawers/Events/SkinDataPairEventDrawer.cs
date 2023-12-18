#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `SkinDataPair`. Inherits from `AtomDrawer&lt;SkinDataPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(SkinDataPairEvent))]
    public class SkinDataPairEventDrawer : AtomDrawer<SkinDataPairEvent> { }
}
#endif
