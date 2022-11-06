using SlotMachine.API.BLs.Interfaces;
using SlotMachine.API.Entities;
using SlotMachine.API.Repositories.Interfaces;
using System.Threading.Tasks;

namespace SlotMachine.API.BLs
{
    public class GameConfigurationBL : IGameConfigurationBL
    {

        private readonly IGameConfigurationRepository _gameConfiguration;

        public GameConfigurationBL(IGameConfigurationRepository gameConfiguration)
        {
            _gameConfiguration = gameConfiguration;
        }

        public async Task UpdateReelsConfigurationAsync(int numOfReels)
        {
            var configuration = await _gameConfiguration.GetConfigurationAsync();
            configuration.NumOfReels = numOfReels;
            await _gameConfiguration.UpdateConfigurationAsync(configuration);
        }
    }
}
