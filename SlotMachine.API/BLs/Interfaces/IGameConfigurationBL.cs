using System.Threading.Tasks;

namespace SlotMachine.API.BLs.Interfaces
{
    public interface IGameConfigurationBL
    {
        Task UpdateReelsConfigurationAsync(int numOfReels);
    }
}