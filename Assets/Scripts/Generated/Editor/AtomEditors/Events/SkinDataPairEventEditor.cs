#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using Skins;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `SkinDataPair`. Inherits from `AtomEventEditor&lt;SkinDataPair, SkinDataPairEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(SkinDataPairEvent))]
    public sealed class SkinDataPairEventEditor : AtomEventEditor<SkinDataPair, SkinDataPairEvent> { }
}
#endif
