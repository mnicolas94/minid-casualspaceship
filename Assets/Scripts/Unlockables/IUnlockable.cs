
using System;

namespace Unlockables
{
    public interface IUnlockable
    {
        bool IsUnlocked();
        void Unlock();

        /// <summary>
        /// Use this to receive a callback when the unlocked state needs to be checked again.
        /// Useful for UIs that check the unlocked state of a skin, and while that skin its being displayed,
        /// an event occurs that made that skin to be unlocked, e.g. a successful connection to a wallet
        /// that owns the skin's NFT. After that connection the UI needs to check the unlocked state again and this
        /// is the callback to know so.
        /// </summary>
        void SubscribeToCheckAgainCallback();
        void UnsubscribeToCheckAgainCallback();
        Action CheckAgainCallback { get; set; }
    }
}