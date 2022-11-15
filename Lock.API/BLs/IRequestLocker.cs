using System.Threading.Tasks;

namespace Lock.API.BLs
{
    public interface IRequestLocker
    {
        Task LockRequestAsync(int playerId);
        Task ReleaseRequestAsync(int playerId);
    }
}