using Azure.Core;
using HomeCleaning.RoomService.Models.DataModel;
using HomeCleaning.RoomService.Models.DataModel.Amenities;
using HomeCleaning.RoomService.Repositories.Amenities;
using Microsoft.EntityFrameworkCore;

namespace HomeCleaning.RoomService.Services.Amenities
{
    public class AmenityService
    {
        private readonly IAmenityRepository _amenityRepository;
        public AmenityService(IAmenityRepository amenityRepository)
        {
            _amenityRepository = amenityRepository;
        }

        public async Task<Amenity?> AddAmenityAsync(string name)
        {
            var existingAmenity = await _amenityRepository.GetByNameAsync(name);
            if (existingAmenity != null)
            {
                // Optionally, you can throw an exception or return false
                return null;
            }
            var amenity = new Amenity
            {
                Name = name,
                AddedDate = DateTime.UtcNow
            };
            return await _amenityRepository.AddAsync(amenity);
        }

        public async Task<List<Amenity>> GetAllAmenitiesAsync()
        {
            return await _amenityRepository.GetAllAsync();
        }

        public async Task<Amenity?> GetById(int id)
        {
            return await _amenityRepository.GetByIdAsync(id);
        }


    }
}
