using System;
using Skins;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Reference of type `Skins.SkinData`. Inherits from `AtomEventReference&lt;Skins.SkinData, SkinDataVariable, SkinDataEvent, SkinDataVariableInstancer, SkinDataEventInstancer&gt;`.
    /// </summary>
    [Serializable]
    public sealed class SkinDataEventReference : AtomEventReference<
        AddressableSkinData,
        SkinDataVariable,
        SkinDataEvent,
        SkinDataVariableInstancer,
        SkinDataEventInstancer>, IGetEvent 
    { }
}
