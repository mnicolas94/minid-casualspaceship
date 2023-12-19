using UnityEngine;
using UnityAtoms.BaseAtoms;
using Skins;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Variable Instancer of type `Skins.SkinData`. Inherits from `AtomVariableInstancer&lt;SkinDataVariable, SkinDataPair, Skins.SkinData, SkinDataEvent, SkinDataPairEvent, SkinDataSkinDataFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-hotpink")]
    [AddComponentMenu("Unity Atoms/Variable Instancers/SkinData Variable Instancer")]
    public class SkinDataVariableInstancer : AtomVariableInstancer<
        SkinDataVariable,
        SkinDataPair,
        AddressableSkinData,
        SkinDataEvent,
        SkinDataPairEvent,
        SkinDataSkinDataFunction>
    { }
}
