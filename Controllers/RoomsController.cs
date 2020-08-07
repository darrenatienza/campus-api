using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampusISApi.Model;
using CampusISApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CampusISApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService ?? throw new ArgumentNullException(nameof(roomService)); // Guard
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Room>), 200)]
        public async Task<IActionResult> ReadAllAsync()
        {
            var allRooms = await _roomService.ReadAllAsync();
            return Ok(allRooms);
        }
    }
}
