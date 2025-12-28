using HomeCleaning.RoomService.Enums;

namespace HomeCleaning.RoomService.DTO.Room.Responses
{
    public class RoomBedDto
    {
        public int Id { get; set; }
        public BedType BedType { get; set; }
        public bool IsActive { get; set; }
    }

}
