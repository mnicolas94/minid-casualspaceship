
using System;

namespace Unlockables
{
    public class AlwaysUnlockable : IUnlockable
    {
        public bool IsUnlocked()
        {
            return true;
        }

        public void Unlock()
        {
            
        }

        public void SubscribeToCheckAgainCallback()
        {
            
        }

        public void UnsubscribeToCheckAgainCallback()
        {
            
        }

        public Action CheckAgainCallback { get; set; }
    }
}