using UnityEngine;
using System;
using Skins;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Variable of type `Skins.SkinData`. Inherits from `AtomVariable&lt;Skins.SkinData, SkinDataPair, SkinDataEvent, SkinDataPairEvent, SkinDataSkinDataFunction&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-lush")]
    [CreateAssetMenu(menuName = "Unity Atoms/Variables/SkinData", fileName = "SkinDataVariable")]
    public sealed class SkinDataVariable : AtomVariable<Skins.SkinData, SkinDataPair, SkinDataEvent, SkinDataPairEvent, SkinDataSkinDataFunction>
    {
        protected override bool ValueEquals(Skins.SkinData other)
        {
            throw new NotImplementedException();
        }
    }
}
