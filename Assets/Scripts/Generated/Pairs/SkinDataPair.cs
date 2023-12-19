using System;
using UnityEngine;
using Skins;
namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// IPair of type `&lt;Skins.SkinData&gt;`. Inherits from `IPair&lt;Skins.SkinData&gt;`.
    /// </summary>
    [Serializable]
    public struct SkinDataPair : IPair<AddressableSkinData>
    {
        public AddressableSkinData Item1 { get => _item1; set => _item1 = value; }
        public AddressableSkinData Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private AddressableSkinData _item1;
        [SerializeField]
        private AddressableSkinData _item2;

        public void Deconstruct(out AddressableSkinData item1, out AddressableSkinData item2) { item1 = Item1; item2 = Item2; }
    }
}