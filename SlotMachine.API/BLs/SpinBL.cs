using SlotMachine.API.BLs.Interfaces;
using SlotMachine.API.Clients;
using SlotMachine.API.Entities;
using SlotMachine.API.Exceptions;
using SlotMachine.API.Models.Requests;
using SlotMachine.API.Models.Responses;
using SlotMachine.API.Repositories.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SlotMachine.API.BLs
{
    public class SpinBL : ISpinBL
    {

        private readonly IGameConfigurationRepository _gameConfiguration;
        private readonly ISpinRepository _spinRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly ILockerClient _lockerClient;

        public SpinBL(IGameConfigurationRepository gameConfiguration, 
            ISpinRepository spinRepository, 
            IPlayerRepository playerRepository, 
            ILockerClient lockerClient)
        {
            _gameConfiguration = gameConfiguration;
            _spinRepository = spinRepository;
            _playerRepository = playerRepository;
            _lockerClient = lockerClient;
        }

        public async Task<SpinResponse> PlayAsync(SpinRequest spinData)
        {
            // get player 
            var player = await _playerRepository.GetPlayerAsync(spinData.PlayerId);
            if (player == null)
                throw new AppException("Player not found", HttpStatusCode.NotFound);

            if (spinData.BetAmount > player.Balance)
                throw new AppException("The amount exceeds the balance", HttpStatusCode.BadRequest);

            await _lockerClient.GetLock(player.Id);

            #region Critial Section

            // get the num of reels from game configuration
            var con = await _gameConfiguration.GetConfigurationAsync();

            // spin the reels
            var spinResult = await SpinReelsAsync(con.NumOfReels);

            // save spin
            Spin spin = new Spin
            {
                Bet = spinData.BetAmount,
                SpinDateTime = DateTime.Now,
                Result = spinResult,
                PlayerId = spinData.PlayerId
            };
            _spinRepository.CreateAsync(spin);


            // calculate the Multiplier
            var reelsMultiplier = await GetConsecutiveResultAsync(spinResult);

            // calculate the win amount
            var winBet = spinData.BetAmount * reelsMultiplier;

            // update the balance
            var newBalance = player.Balance - spinData.BetAmount + winBet;
            await _playerRepository.UpdatePlayerBalanceAsync(spinData.PlayerId, newBalance);

            #endregion Critial Section

            await _lockerClient.GetRelease(player.Id);

            // return the result
            return new SpinResponse
            {
                Balance = newBalance,
                SpinResult = spinResult,
                WinAmount = winBet
            };
        }

        public async Task<int[]> SpinReelsAsync(int numOfReels)
        {
            int[] reels = new int[numOfReels];
            Random r = new Random();

            for (int i = 0; i < numOfReels; i++)
            {
                reels[i] = r.Next(0, 9);
            }

            return reels;
        }

        public async Task<int> GetConsecutiveResultAsync(int[] reels)
        {
            int result = reels[0];
            int previousReel = reels[0];

            for (int i = 1; i < reels.Length; i++)
            {
                if (reels[i] != previousReel)
                    break;

                result += reels[i];
                previousReel = reels[i];
            }

            return result;
        }
    }
}
