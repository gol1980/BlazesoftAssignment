using SlotMachine.API.Entities;
using System.Threading.Tasks;

namespace SlotMachine.API.Repositories.Interfaces
{
    public interface IPlayerRepository
    {
        Task<Player> GetPlayerAsync(int id);
        Task<bool> UpdatePlayerBalanceAsync(int id, int amount);
    }
}