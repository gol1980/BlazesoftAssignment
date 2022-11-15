using System.Threading.Tasks;

namespace SlotMachine.API.Clients
{
    public interface ILockerClient
    {
        Task GetLock(int playerId);
        Task GetRelease(int playerId);
    }
}