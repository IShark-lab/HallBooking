using HallBooking.BLL.Interfaces;
using HallBooking.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HallBooking.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;

        public BookingController(IBookingService service)
        {
            this._service = service;
        }

        //Зарезервувати новий зал
        [HttpPost]
        public async Task<ActionResult> BookRoom(BookingDto booking)
        {
            var result = await _service.ReservationAsync(booking);

            if(!result.Success)
                return BadRequest(result);

            return Ok(result.Message);

        }
        //Отримати усi зали якi можно орендувати отталкиваясь вiд вхiдних данних
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConferenceRoomDto>>> GetAvaibleRooms(DateTime strateTime,DateTime endTime, int amountPersons)
        {
            var result = await _service.GetAllAvaibleRooms(strateTime, endTime, amountPersons);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

    }
}
