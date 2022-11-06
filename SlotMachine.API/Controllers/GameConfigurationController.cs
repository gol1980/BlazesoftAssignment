using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlotMachine.API.BLs.Interfaces;
using SlotMachine.API.Controllers.Base;
using SlotMachine.API.Repositories.Interfaces;
using System.Threading.Tasks;

namespace SlotMachine.API.Controllers
{
    public class GameConfigurationController : BaseController<GameConfigurationController>
    {

        private readonly IGameConfigurationBL _gameConfigurationBL;

        public GameConfigurationController(IGameConfigurationBL gameConfigurationBL)
        {
            _gameConfigurationBL = gameConfigurationBL;
        }

        [HttpPost("reels")]
        public async Task<IActionResult> UpdateReelsConfiguration(int numOfReels)
        {
            await _gameConfigurationBL.UpdateReelsConfigurationAsync(numOfReels);
            return Ok();
        }
    }
}
