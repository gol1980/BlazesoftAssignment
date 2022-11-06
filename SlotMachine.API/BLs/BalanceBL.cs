using SlotMachine.API.BLs.Interfaces;
using SlotMachine.API.Exceptions;
using SlotMachine.API.Models.Requests;
using SlotMachine.API.Repositories.Interfaces;
using System.Net;
using System.Threading.Tasks;

namespace SlotMachine.API.BLs
{
    public class BalanceBL : IBalanceBL
    {
        private readonly IPlayerRepository _playerRepository;

        public BalanceBL(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<bool> AddAmountToPlayerAsync(AddAmountRequest amountData)
        {
            var player = await _playerRepository.GetPlayerAsync(amountData.PlayerId);
            return await _playerRepository.UpdatePlayerBalanceAsync(amountData.PlayerId, player.Balance + amountData.Amount);
        }

        public async Task<int> GetPlayerBalanceAsync(int playerId)
        {
            var player = await _playerRepository.GetPlayerAsync(playerId);
            return player.Balance;
        }
    }
}
