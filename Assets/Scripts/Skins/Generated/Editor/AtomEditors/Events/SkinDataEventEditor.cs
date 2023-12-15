#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine.UIElements;
using UnityAtoms.Editor;
using Skins;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Event property drawer of type `Skins.SkinData`. Inherits from `AtomEventEditor&lt;Skins.SkinData, SkinDataEvent&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomEditor(typeof(SkinDataEvent))]
    public sealed class SkinDataEventEditor : AtomEventEditor<Skins.SkinData, SkinDataEvent> { }
}
#endif
