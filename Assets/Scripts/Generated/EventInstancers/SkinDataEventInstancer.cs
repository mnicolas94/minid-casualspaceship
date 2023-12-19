using UnityEngine;
using Skins;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Event Instancer of type `Skins.SkinData`. Inherits from `AtomEventInstancer&lt;Skins.SkinData, SkinDataEvent&gt;`.
    /// </summary>
    [EditorIcon("atom-icon-sign-blue")]
    [AddComponentMenu("Unity Atoms/Event Instancers/SkinData Event Instancer")]
    public class SkinDataEventInstancer : AtomEventInstancer<AddressableSkinData, SkinDataEvent> { }
}
