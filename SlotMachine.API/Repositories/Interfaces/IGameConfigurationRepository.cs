using SlotMachine.API.Entities;
using System.Threading.Tasks;

namespace SlotMachine.API.Repositories.Interfaces
{
    public interface IGameConfigurationRepository
    {
        Task<GameConfiguration> GetConfigurationAsync();
        Task<bool> UpdateConfigurationAsync(GameConfiguration configuration);
    }
}