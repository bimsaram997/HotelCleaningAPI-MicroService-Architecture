using HomeCleaning.RoomService.Models.DataModel;
using HomeCleaning.RoomService.Models.DataModel.Amenities;
using HotelCleaning.Context;
using Microsoft.EntityFrameworkCore;

namespace HomeCleaning.RoomService.Repositories.Amenities
{
    public class AmenityRepository : IAmenityRepository
    {
        private readonly RoomDbContext _context;

        public AmenityRepository(RoomDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Amenity> AddAsync(Amenity amenity)
        {
            _context.Amenities.Add(amenity);
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task<List<Amenity>> GetAllAsync()
        {
            return await _context.Amenities.Where(u => !u.IsDeleted).ToListAsync();
        }

        public async Task<Amenity?> GetByNameAsync(string name)
        {
            return await _context.Amenities.FirstOrDefaultAsync(a => EF.Functions.Like(a.Name, $"%{name}%"));
        }

        public async Task<Amenity?> GetByIdAsync(int id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted);
        }
    }
}
