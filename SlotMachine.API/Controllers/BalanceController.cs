using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SlotMachine.API.BLs.Interfaces;
using SlotMachine.API.Controllers.Base;
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

        [HttpPost("update")]
        public async Task<IActionResult> UpdateBalance(int playerId, int amount)
        {
            await _balanceBL.AddAmountToPlayerAsync(playerId, amount);
            return Ok();
        }
    }
}
