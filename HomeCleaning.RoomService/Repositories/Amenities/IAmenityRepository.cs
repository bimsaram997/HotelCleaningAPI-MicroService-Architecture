using HomeCleaning.RoomService.Models.DataModel.Amenities;

namespace HomeCleaning.RoomService.Repositories.Amenities
{
    public interface IAmenityRepository
    {
        Task<Amenity> AddAsync(Amenity amenity);
        Task<List<Amenity>> GetAllAsync();
        Task<Amenity?> GetByNameAsync(string name);
        Task<Amenity?> GetByIdAsync(int id);
    }
}
