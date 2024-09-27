using HallBooking.BLL.Interfaces;
using HallBooking.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace HallBooking.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferenceRoomController : ControllerBase
    {
        private readonly IConferenceRoomService _service;

        public ConferenceRoomController(IConferenceRoomService service)
        {
            this._service = service;
        }

        //Додати новий зал
        [HttpPost]
        public async Task<ActionResult<int>> PostConferenceRoom(ConferenceRoomDto conferenceRoomDto)
        {
            var result = await _service.CreateAsync(conferenceRoomDto);

            if (result is null)
                return BadRequest("Error creating conference room.");

            return Ok(new {ID = result, Message = $"New conference room was created by ID - {result}"});
        }

        //Удалии зал по id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteConferenceRoom(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

           return Ok(result.Message);

        }

        //Редагувати зал
        [HttpPut]
        public async Task<ActionResult> UpdateConferenceRoom(int id, ConferenceRoomDto conferenceRoomDto)
        {
            var result = await _service.UpdateAsync(id, conferenceRoomDto);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message); 
        }



    }
}
