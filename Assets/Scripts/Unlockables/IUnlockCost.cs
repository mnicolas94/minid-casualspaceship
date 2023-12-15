using System.Threading;
using System.Threading.Tasks;

namespace Unlockables
{
    public interface IUnlockCost
    {
        Task<bool> CanAfford(CancellationToken ct);
        Task<bool> PayCost(CancellationToken ct);
    }
}