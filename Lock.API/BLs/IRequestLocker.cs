using System.Threading.Tasks;

namespace Lock.API.BLs
{
    public interface IRequestLocker
    {
        Task LockRequest();
        Task ReleaseRequest();
    }
}