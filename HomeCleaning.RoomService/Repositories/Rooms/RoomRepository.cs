using HomeCleaning.RoomService.Models.DataModel.Room;
using HotelCleaning.Context;
using Microsoft.EntityFrameworkCore;

namespace HomeCleaning.RoomService.Repositories.Rooms
{
    public class RoomRepository : IRoomRepository
    {

        private readonly RoomDbContext _context;

        public RoomRepository(RoomDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Room> AddAsync(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public Task<List<Room>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Room?> GetByIdAsync(int id)
        {
            return await _context.Rooms
              .Include(r => r.Beds)
              .Include(r => r.RoomAmenities)
              .ThenInclude(a => a.Amenity)
              .FirstOrDefaultAsync(r => r.Id == id);
        }
    }
}
