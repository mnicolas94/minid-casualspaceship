using System;
using UnityEngine;
using Skins;
namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// IPair of type `&lt;Skins.SkinData&gt;`. Inherits from `IPair&lt;Skins.SkinData&gt;`.
    /// </summary>
    [Serializable]
    public struct SkinDataPair : IPair<Skins.SkinData>
    {
        public Skins.SkinData Item1 { get => _item1; set => _item1 = value; }
        public Skins.SkinData Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private Skins.SkinData _item1;
        [SerializeField]
        private Skins.SkinData _item2;

        public void Deconstruct(out Skins.SkinData item1, out Skins.SkinData item2) { item1 = Item1; item2 = Item2; }
    }
}