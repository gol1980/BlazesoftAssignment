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
        [Route("Lock/{id}")]
        public async Task<IActionResult> LockRequest(int id)
        {
            await _requestLocker.LockRequestAsync(id);

            return Ok();
        }

        [HttpGet]
        [Route("Release/{id}")]
        public async Task<IActionResult> ReleaseRequest(int id)
        {
            await _requestLocker.ReleaseRequestAsync(id);

            return Ok();
        }
    }
}