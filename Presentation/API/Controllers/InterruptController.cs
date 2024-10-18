using Application;
using Application.Mapping;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterruptController : ControllerBase
    {
        private readonly InterruptMapper _interruptMapper;
        private readonly IDeviceRepository _deviceRepository;
        private readonly IPingServices _pingService;

        public InterruptController(IDeviceRepository deviceRepository, IPingServices pingService)
        {
            //Mapper için dependency injection yapılmadı çünkü interface ya da repository si yok
            _deviceRepository = deviceRepository;
            _pingService = pingService;
            _interruptMapper = new InterruptMapper(); //direkt örnek oluşturma
        }

        [HttpGet("GetReport")]
        public async Task<IActionResult> GetReport()
        {
            //Database den device verilerini al
            var devices = _deviceRepository.GetTotalData();

            //Servisten ping verilerini al
            var pings =  await _pingService.GetAllPings();

            //Verileri MappReport fonksiyonu ile işleyip kullanıcıya dön.
            var result = _interruptMapper.MappReport(devices.Data, pings);
            return Ok(result);

        }
    }
}
