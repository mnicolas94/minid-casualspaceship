using System.Threading.Tasks;

namespace Unlockables
{
    public interface IUnlockCost
    {
        Task<bool> CanAfford();
        Task<bool> PayCost();
    }
}