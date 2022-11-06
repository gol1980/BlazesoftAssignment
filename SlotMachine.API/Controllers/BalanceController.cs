using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlotMachine.API.BLs.Interfaces;
using SlotMachine.API.Controllers.Base;
using SlotMachine.API.Models.Requests;
using SlotMachine.API.Repositories.Interfaces;
using System.Threading.Tasks;

namespace SlotMachine.API.Controllers
{
    public class BalanceController : BaseController<BalanceController>
    {
        private readonly IBalanceBL _balanceBL;

        public BalanceController(IBalanceBL balanceBL)
        {
            _balanceBL = balanceBL;
        }

        [HttpPost("AddAmountToPlayer")]
        public async Task<IActionResult> AddAmountToPlayer(AddAmountRequest amountData)
        {
            await _balanceBL.AddAmountToPlayerAsync(amountData);
            return Ok();
        }

        [HttpGet("GetBalance/{playerId}")]
        public async Task<IActionResult> GetPlayerBalance(int playerId)
        {
            var result = await _balanceBL.GetPlayerBalanceAsync(playerId);
            return Ok(result);
        }
    }
}
