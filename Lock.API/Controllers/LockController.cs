using Lock.API.BLs;
using Lock.API.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lock.API.Controllers
{
    public class LockController : BaseController<LockController>
    {
        private readonly IRequestLocker _requestLocker;

        public LockController(IRequestLocker requestLocker)
        {
            _requestLocker = requestLocker;
        }

        [HttpGet]
        [Route("Lock")]
        public async Task<IActionResult> LockRequest()
        {
            await _requestLocker.LockRequest();

            return Ok();
        }

        [HttpGet]
        [Route("Release")]
        public async Task<IActionResult> ReleaseRequest()
        {
            await _requestLocker.ReleaseRequest();

            return Ok();
        }
    }
}