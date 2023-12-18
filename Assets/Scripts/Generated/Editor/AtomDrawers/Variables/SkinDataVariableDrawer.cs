#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityAtoms.Editor;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable property drawer of type `Skins.SkinData`. Inherits from `AtomDrawer&lt;SkinDataVariable&gt;`. Only availble in `UNITY_2019_1_OR_NEWER`.
    /// </summary>
    [CustomPropertyDrawer(typeof(SkinDataVariable))]
    public class SkinDataVariableDrawer : VariableDrawer<SkinDataVariable> { }
}
#endif
