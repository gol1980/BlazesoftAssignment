using SlotMachine.API.BLs.Interfaces;
using SlotMachine.API.Entities;
using SlotMachine.API.Exceptions;
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

        public SpinBL(IGameConfigurationRepository gameConfiguration,
            ISpinRepository spinRepository,
            IPlayerRepository playerRepository)
        {
            _gameConfiguration = gameConfiguration;
            _spinRepository = spinRepository;
            _playerRepository = playerRepository;
        }


        public async Task<SpinResponse> Play(int playerId, int betAmount)
        {

            // get player 
            var player = await _playerRepository.GetPlayerAsync(playerId);
            if (player == null)
                throw new AppException("Player not found", HttpStatusCode.NotFound);

            if(betAmount > player.Balance)
                throw new AppException("Bet is higher than balance amount", HttpStatusCode.BadRequest);


            // get the num of reels from game configuration
            var con = await _gameConfiguration.GetConfigurationAsync();

            // spin the reels
            //var spinResult = SpinReels(con.NumOfReels);
            var spinResult = new int[] { 5,5,1};

            // save spin
            Spin spin = new Spin
            {
                Bet = betAmount,
                SpinDateTime = DateTime.Now,
                Result = spinResult,
                PlayerId = playerId
            };
            var tSpin = _spinRepository.CreateAsync(spin);


            // calculate the Multiplier
            var reelsMultiplier = GetConsecutiveResult(spinResult);

            // calculate the win amount
            var winBet = betAmount * reelsMultiplier;

            // update the balance
            var newBalance = player.Balance - betAmount + winBet;
            var isSaved = await _playerRepository.UpdatePlayerBalanceAsync(playerId, newBalance);

            await tSpin;
            if (isSaved)
            {
                // return the result
                return new SpinResponse
                {
                    Balance = newBalance,
                    SpinResult = spinResult,
                    WinAmount = winBet
                };
            }
            else
                throw new AppException("Balance Update Error", HttpStatusCode.InternalServerError);

        }

        private int[] SpinReels(int numOfReels)
        {
            int[] reels = new int[numOfReels];
            Random r = new Random();

            for (int i = 0; i < numOfReels; i++)
            {
                reels[i] = r.Next(0, 9);
            }

            return reels;
        }

        private int GetConsecutiveResult(int[] reels)
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
