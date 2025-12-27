using HomeCleaning.RoomService.DTO.Room;
using HomeCleaning.RoomService.Models.DataModel.Room;
using HomeCleaning.RoomService.Repositories.Rooms;

namespace HomeCleaning.RoomService.Services.Rooms
{
    public class RoomService
    {
        private readonly IRoomRepository _repository;
        public RoomService(IRoomRepository repository)
        {
            _repository = repository;
        }

        public async Task<Room?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Room> CreateRoomAsync(Room room)
        {
            
            
            return await _repository.AddAsync(room);
        }
    }
}
