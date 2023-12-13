using System.Threading;
using System.Threading.Tasks;

namespace Unlockables
{
    public interface ILoadable
    {
        Task Load(CancellationToken ct);
    }
}