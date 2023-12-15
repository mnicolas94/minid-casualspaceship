using System;
using UnityAtoms.BaseAtoms;
using Skins;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Reference of type `Skins.SkinData`. Inherits from `AtomReference&lt;Skins.SkinData, SkinDataPair, SkinDataConstant, SkinDataVariable, SkinDataEvent, SkinDataPairEvent, SkinDataSkinDataFunction, SkinDataVariableInstancer, AtomCollection, AtomList&gt;`.
    /// </summary>
    [Serializable]
    public sealed class SkinDataReference : AtomReference<
        Skins.SkinData,
        SkinDataPair,
        SkinDataConstant,
        SkinDataVariable,
        SkinDataEvent,
        SkinDataPairEvent,
        SkinDataSkinDataFunction,
        SkinDataVariableInstancer>, IEquatable<SkinDataReference>
    {
        public SkinDataReference() : base() { }
        public SkinDataReference(Skins.SkinData value) : base(value) { }
        public bool Equals(SkinDataReference other) { return base.Equals(other); }
        protected override bool ValueEquals(Skins.SkinData other)
        {
            throw new NotImplementedException();
        }
    }
}
