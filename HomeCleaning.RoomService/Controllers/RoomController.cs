using HomeCleaning.RoomService.DTO.Room;
using HomeCleaning.RoomService.Services.Rooms;
using Microsoft.AspNetCore.Mvc;

namespace HomeCleaning.RoomService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController: ControllerBase
    {
        private readonly RoomsService _roomService;
        public RoomController(RoomsService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost("createRoom")]
        public async Task<IActionResult> CreateRoom(CreateRoomRequest request)
        {
            var room = await _roomService.CreateRoomAsync(request);
            return Ok(room);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rooms = await _roomService.GetAllAsync();
            return Ok(rooms);
        }

    }
}
