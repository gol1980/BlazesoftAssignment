using SlotMachine.API.Models.Requests;
using System.Threading.Tasks;

namespace SlotMachine.API.BLs.Interfaces
{
    public interface IGameConfigurationBL
    {
        Task UpdateReelsConfigurationAsync(GameConfigurationRequest configurationData);
    }
}