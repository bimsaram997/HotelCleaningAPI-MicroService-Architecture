using HomeCleaning.RoomService.Models.DataModel;
using HomeCleaning.RoomService.Models.DataModel.Amenities;
using HomeCleaning.RoomService.Models.DataModel.Room;

namespace HomeCleaning.RoomService.Repositories.Rooms
{
    public interface IRoomRepository
    {
        Task<Room> AddAsync(Room room);
        Task<Room?> GetByIdAsync(int id);
        Task<List<Room>> GetAllAsync();

    }
}
