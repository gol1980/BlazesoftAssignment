using MongoDB.Driver;
using SlotMachine.API.Data.Interfaces;
using SlotMachine.API.Entities;
using SlotMachine.API.Repositories.Base;
using SlotMachine.API.Repositories.Interfaces;
using System.Threading.Tasks;

namespace SlotMachine.API.Repositories
{
    public class PlayerRepository : BaseRepository, IPlayerRepository
    {

        public PlayerRepository(IGameContext context)
            : base(context)
        {
        }

        public async Task<Player> GetPlayerAsync(int id)
        {
            return await _context.Players.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdatePlayerBalanceAsync(int id, int amount)
        {
            var update = Builders<Player>.Update.Set(p => p.Balance, amount);

            var updateResult = await _context.Players.UpdateOneAsync(p => p.Id == id, update);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
