using MongoDB.Driver;
using SlotMachine.API.Data.Interfaces;
using SlotMachine.API.Entities;
using SlotMachine.API.Repositories.Base;
using SlotMachine.API.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace SlotMachine.API.Repositories
{
    public class GameConfigurationRepository: BaseRepository, IGameConfigurationRepository
    {
        public GameConfigurationRepository(IGameContext context)
           : base(context)
        {
        }

        public async Task<GameConfiguration> GetConfigurationAsync()
        {
            return await _context.Configuration.Find(_ => true).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateConfigurationAsync(GameConfiguration configuration)
        {
            var updateResult = await _context.Configuration.ReplaceOneAsync(c => true, configuration);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
