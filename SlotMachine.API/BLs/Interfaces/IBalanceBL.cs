using System.Threading.Tasks;

namespace SlotMachine.API.BLs.Interfaces
{
    public interface IBalanceBL
    {
        Task<bool> AddAmountToPlayerAsync(int playerId, int amountToAdd);
    }
}