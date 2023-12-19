using UnityEngine;
using Skins;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Constant of type `Skins.SkinData`. Inherits from `AtomBaseVariable&lt;Skins.SkinData&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-teal")]
    [CreateAssetMenu(menuName = "Unity Atoms/Constants/SkinData", fileName = "SkinDataConstant")]
    public sealed class SkinDataConstant : AtomBaseVariable<AddressableSkinData> { }
}
