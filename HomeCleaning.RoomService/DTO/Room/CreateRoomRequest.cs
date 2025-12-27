using HomeCleaning.RoomService.DTO.Amenities;
using HomeCleaning.RoomService.Enums;

namespace HomeCleaning.RoomService.DTO.Room
{
    public class CreateRoomRequest
    {
        public string RoomNumber { get; set; }
        public RoomType Type { get; set; }
        public RoomStatus Status { get; set; }
        public int DefaultBedCount { get; set; } = 2;

        // Superior options
        public bool HasMilkPackets { get; set; }
        public bool HasCoffeePackets { get; set; }
        public bool HasSugarPackets { get; set; }

        // Amenity Ids + Quantity
        public List<AmenityQuantityDto> Amenities { get; set; } = new();

        // Extra beds
        public List<BedType> ExtraBeds { get; set; } = new();
    }
}
