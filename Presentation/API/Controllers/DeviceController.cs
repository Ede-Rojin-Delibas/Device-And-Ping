using Application;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    [Route("api/[controller]")]    //URL pattern tanımlanır.
    [ApiController]
    public class DeviceController : ControllerBase
    {
        //DEPENDENCY INJECTION
        private readonly IDeviceRepository _deviceRepository;

        public DeviceController(IDeviceRepository deviceRepository) 
        {
            _deviceRepository = deviceRepository;       //enjekte etme
            
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll() 
        {
            var model = _deviceRepository.GetTotalData();

            if ( model.hasError)
            {
                model.errorList.Add("Hata bulundu.");
            }
           
            return Ok(model);

        }
        
      

    }
}
