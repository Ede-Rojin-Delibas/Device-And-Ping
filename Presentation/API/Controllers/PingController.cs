using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")] // api name->Ping
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly IPingServices _pingServices;
        public PingController(IPingServices pingServices)
        {
            _pingServices = pingServices;
        }


        [HttpGet("GetPings")]
        public async Task <IActionResult> GetPings()
        {
            var model = await _pingServices.GetAllPings();
            return Ok(model);

        }

    }
}
