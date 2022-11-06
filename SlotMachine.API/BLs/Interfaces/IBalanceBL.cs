using SlotMachine.API.Models.Requests;
using System.Threading.Tasks;

namespace SlotMachine.API.BLs.Interfaces
{
    public interface IBalanceBL
    {
        Task<bool> AddAmountToPlayerAsync(AddAmountRequest amountData);
        Task<int> GetPlayerBalanceAsync(int playerId);
    }
}