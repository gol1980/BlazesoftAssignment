using SlotMachine.API.BLs.Interfaces;
using SlotMachine.API.Exceptions;
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

        public async Task<bool> AddAmountToPlayerAsync(int playerId, int amountToAdd)
        {
            var player = await _playerRepository.GetPlayerAsync(playerId);
            return await _playerRepository.UpdatePlayerBalanceAsync(playerId, player.Balance + amountToAdd);
        }
    }
}
