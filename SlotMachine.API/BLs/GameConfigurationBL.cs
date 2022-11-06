using SlotMachine.API.BLs.Interfaces;
using SlotMachine.API.Entities;
using SlotMachine.API.Exceptions;
using SlotMachine.API.Models.Requests;
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

        public async Task UpdateReelsConfigurationAsync(GameConfigurationRequest configurationData)
        {
            if (configurationData.NumOfReels < 3)
                throw new AppException("Number of reels cannot be less than 3", System.Net.HttpStatusCode.BadRequest);

            var configuration = await _gameConfiguration.GetConfigurationAsync();
            configuration.NumOfReels = configurationData.NumOfReels;
            await _gameConfiguration.UpdateConfigurationAsync(configuration);
        }
    }
}
