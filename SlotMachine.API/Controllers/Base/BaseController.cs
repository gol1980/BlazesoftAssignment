using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace SlotMachine.API.Controllers.Base
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : BaseController<T>
    {
        private ILogger<T> _logger;
        protected ILogger<T> logger => _logger ?? (_logger = HttpContext.RequestServices.GetService<ILogger<T>>());
    }
}
