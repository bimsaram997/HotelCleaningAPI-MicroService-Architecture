using HomeCleaning.RoomService.DTO.Room;
using HomeCleaning.RoomService.DTO.Room.Responses;
using HomeCleaning.RoomService.Enums;
using HomeCleaning.RoomService.Models.DataModel.Room;
using HomeCleaning.RoomService.Repositories.Rooms;

namespace HomeCleaning.RoomService.Services.Rooms
{
    public class RoomsService
    {
        private readonly IRoomRepository _repository;
        public RoomsService(IRoomRepository repository)
        {
            _repository = repository;
        }

        public async Task<Room?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Room> CreateRoomAsync(CreateRoomRequest request)
        {
            var room = new Room
            {
                RoomNumber = request.RoomNumber,
                DefaultBedCount = request.DefaultBedCount,
                Type = request.Type,
                Status = request.Status,
                AddedDate = DateTime.UtcNow,
                HasMilkPackets = request.HasMilkPackets,
                HasCoffeePackets = request.HasCoffeePackets,
                HasSugarPackets = request.HasSugarPackets
            };

            var defaultBedCount = room.DefaultBedCount;
            for (int i = 0; i < defaultBedCount; i++)
            {
                room.Beds.Add(new RoomBed { 
                    BedType = BedType.Default,
                    AddedDate = DateTime.UtcNow
                });
            }

            // Track rolling bed count
            bool rollingBedAdded = false;
            // Add Extra beds if specified
            int sofaBedCount = request.ExtraBeds.Count(bed => bed == BedType.SofaBed);

            foreach (var bedType in request.ExtraBeds)
            {
                if (bedType == BedType.RollingBed) { 
                    if(!rollingBedAdded)
                    {
                        room.Beds.Add(new RoomBed { BedType = BedType.RollingBed });
                        rollingBedAdded = true;
                    }
                }else if (bedType == BedType.SofaBed)
                {
                    if (sofaBedCount < 2)
                    {
                        room.Beds.Add(new RoomBed { BedType = BedType.SofaBed, AddedDate = DateTime.UtcNow });
                        sofaBedCount--;
                    }
                }
            }

            // Add amenities
            foreach (var amenity in request.Amenities)
            {
                room.RoomAmenities.Add(new RoomAmenity
                {
                    AmenityId = amenity.AmenityId,
                    Quantity = amenity.Quantity,
                    AddedDate = DateTime.UtcNow
                });
            }

            return await _repository.AddAsync(room);
        }

        public async Task<List<RoomResponseDto>> GetAllAsync()
        {
            var rooms = await _repository.GetAllAsync();
            return rooms.Select(MapToDto).ToList();
        }
        private RoomResponseDto MapToDto(Room room)
        {
            return new RoomResponseDto
            {
                Id = room.Id,
                RoomNumber = room.RoomNumber,
                DefaultBedCount = room.DefaultBedCount,
                Type = room.Type,
                Status = room.Status,
                HasMilkPackets = room.HasMilkPackets,
                HasCoffeePackets = room.HasCoffeePackets,
                HasSugarPackets = room.HasSugarPackets,

                Beds = room.Beds.Select(b => new RoomBedDto
                {
                    Id = b.Id,
                    BedType = b.BedType,
                    IsActive = b.IsActive
                }).ToList(),

                Amenities = room.RoomAmenities.Select(a => new RoomAmenityDto
                {
                    AmenityId = a.AmenityId,
                    AmenityName = a.Amenity.Name,
                    Quantity = a.Quantity
                }).ToList()
            };
        }
    }
}
