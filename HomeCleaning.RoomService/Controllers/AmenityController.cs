using HomeCleaning.RoomService.DTO.Amenities;
using HomeCleaning.RoomService.Models.DataModel;
using HomeCleaning.RoomService.Models.DataModel.Amenities;
using HomeCleaning.RoomService.Repositories;
using HomeCleaning.RoomService.Services.Amenities;
using Microsoft.AspNetCore.Mvc;

namespace HomeCleaning.RoomService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AmenityController: ControllerBase
    {
        private readonly AmenityService _amenityService;

        public AmenityController(AmenityService amenityService)
        {
            _amenityService = amenityService;
        }

        [HttpPost("addAmenity")]
        public async Task<IActionResult> AddAmenity([FromBody] CreateAmenityRequest request)
        {
            
            var addedAmenity = await _amenityService.AddAmenityAsync(request.Name);
            if (addedAmenity != null) {
                return Ok(addedAmenity);
            }
            else
            {
                return BadRequest("Amenity already exists.");
            }
            
        }

        [HttpGet("getAllAmenities")]
        public async Task<IActionResult> GetAllAmenities()
        {
            var amenities = await _amenityService.GetAllAmenitiesAsync();
            return Ok(amenities);
        }

        [HttpGet("getAmenityById/{id}")]
        public async Task<IActionResult> GetAmenityById(int id)
        {
            var amenity = await _amenityService.GetById(id);
            if (amenity == null)
            {
                return NotFound();
            }
            return Ok(amenity);
        }
    }
}
