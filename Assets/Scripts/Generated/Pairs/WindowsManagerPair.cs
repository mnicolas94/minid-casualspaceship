using System;
using UnityEngine;
using UI;
namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// IPair of type `&lt;UI.WindowsManager&gt;`. Inherits from `IPair&lt;UI.WindowsManager&gt;`.
    /// </summary>
    [Serializable]
    public struct WindowsManagerPair : IPair<UI.WindowsManager>
    {
        public UI.WindowsManager Item1 { get => _item1; set => _item1 = value; }
        public UI.WindowsManager Item2 { get => _item2; set => _item2 = value; }

        [SerializeField]
        private UI.WindowsManager _item1;
        [SerializeField]
        private UI.WindowsManager _item2;

        public void Deconstruct(out UI.WindowsManager item1, out UI.WindowsManager item2) { item1 = Item1; item2 = Item2; }
    }
}