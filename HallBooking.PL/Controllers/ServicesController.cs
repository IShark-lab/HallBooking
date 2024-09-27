using HallBooking.BLL.Interfaces;
using HallBooking.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace HallBooking.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesService _service;

        public ServicesController(IServicesService service)
        {
            this._service = service;
        }

        //HTTPGET отримати усi сервicи з пагiнацiей
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceDto>>> Get(int page = 1, int pageSize = 5) 
        {
            var serviceDtos = await _service.GetAllServices(page,pageSize);

            if(serviceDtos is null)
                return NotFound();

            return Ok(serviceDtos);
        }

    }
}
