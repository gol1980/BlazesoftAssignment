using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlotMachine.API.BLs.Interfaces;
using SlotMachine.API.Controllers.Base;
using SlotMachine.API.Models.Requests;
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
        public async Task<IActionResult> UpdateReelsConfiguration(GameConfigurationRequest configurationData)
        {
            await _gameConfigurationBL.UpdateReelsConfigurationAsync(configurationData);
            return Ok();
        }
    }
}
