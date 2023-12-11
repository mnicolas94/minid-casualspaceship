using System;
using UnityAtoms.BaseAtoms;
using UI;

namespace UnityAtoms.BaseAtoms
{
    /// <summary>
    /// Reference of type `UI.WindowsManager`. Inherits from `AtomReference&lt;UI.WindowsManager, WindowsManagerPair, WindowsManagerConstant, WindowsManagerVariable, WindowsManagerEvent, WindowsManagerPairEvent, WindowsManagerWindowsManagerFunction, WindowsManagerVariableInstancer, AtomCollection, AtomList&gt;`.
    /// </summary>
    [Serializable]
    public sealed class WindowsManagerReference : AtomReference<
        UI.WindowsManager,
        WindowsManagerPair,
        WindowsManagerConstant,
        WindowsManagerVariable,
        WindowsManagerEvent,
        WindowsManagerPairEvent,
        WindowsManagerWindowsManagerFunction,
        WindowsManagerVariableInstancer>, IEquatable<WindowsManagerReference>
    {
        public WindowsManagerReference() : base() { }
        public WindowsManagerReference(UI.WindowsManager value) : base(value) { }
        public bool Equals(WindowsManagerReference other) { return base.Equals(other); }
        protected override bool ValueEquals(UI.WindowsManager other)
        {
            throw new NotImplementedException();
        }
    }
}
