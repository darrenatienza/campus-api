using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Campus.Services.IServices;
using CampusISApi.Model;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Logging;

namespace CampusISApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class RoomsController : ControllerBase
    {
        IRoomServices _roomService;
        public RoomsController(IRoomServices roomService)
        {
            _roomService = roomService ?? throw new NotImplementedException(nameof(roomService));
        }
        [HttpGet]
        public async Task<IActionResult> ReadAllAsync()
        {
            return Ok(await _roomService.GetAllRooms());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadByRoomID(int id)
        {
            try
            {
                var room = _roomService.GetRoom(id);
                if (room.Result != null)
                {
                    return Ok(await _roomService.GetRoom(id));
                }
                return NotFound();

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,ex);
            }
            
            
        }
        [HttpGet("room-key/{roomKey}")]
        public async Task<IActionResult> ReadByRoomKey(Guid roomKey)
        {
            try
            {
                var room = _roomService.GetRoom(roomKey);
                if (room.Result != null)
                {
                    return Ok(await _roomService.GetRoom(roomKey));
                }
                return NotFound();

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }


        }
    }
}
