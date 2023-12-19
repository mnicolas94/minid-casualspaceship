using UnityEditor;
using UnityAtoms.Editor;
using Skins;

namespace UnityAtoms.BaseAtoms.Editor
{
    /// <summary>
    /// Variable Inspector of type `Skins.SkinData`. Inherits from `AtomVariableEditor`
    /// </summary>
    [CustomEditor(typeof(SkinDataVariable))]
    public sealed class SkinDataVariableEditor : AtomVariableEditor<AddressableSkinData, SkinDataPair> { }
}
