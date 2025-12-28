using HomeCleaning.RoomService.Enums;

namespace HomeCleaning.RoomService.DTO.Room.Responses
{
    public class RoomResponseDto
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int DefaultBedCount { get; set; }
        public RoomType Type { get; set; }
        public RoomStatus Status { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool HasMilkPackets { get; set; }
        public bool HasCoffeePackets { get; set; }
        public bool HasSugarPackets { get; set; }

        public List<RoomBedDto> Beds { get; set; }
        public List<RoomAmenityDto> Amenities { get; set; }
    }

}
