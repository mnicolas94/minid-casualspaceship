
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Unlockables
{
    public interface IUnlockablesStorage<T>
    {
        Task Initialize(CancellationToken ct);
        Task Dispose(CancellationToken ct);
        Task<bool> IsUnlocked(T t, CancellationToken ct);
        Task Unlock(T t, CancellationToken ct);
        Action<T> UnlockedEvent { get; set; }
    }
}