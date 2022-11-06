using Microsoft.AspNetCore.Mvc;
using SlotMachine.API.BLs.Interfaces;
using SlotMachine.API.Controllers.Base;
using SlotMachine.API.Models.Requests;
using SlotMachine.API.Models.Responses;
using System.Threading.Tasks;

namespace SlotMachine.API.Controllers
{
    public class SpinController : BaseController<SpinController>
    {

        private readonly ISpinBL _spinBL;
       
        public SpinController(ISpinBL spinBL)
        {
            _spinBL = spinBL;
        }

        [HttpPost]
        public async Task<ActionResult<SpinResponse>> Spin(SpinRequest spinData)
        {
            var result = await _spinBL.PlayAsync(spinData);
            return Ok(result);
        }
    }
}
