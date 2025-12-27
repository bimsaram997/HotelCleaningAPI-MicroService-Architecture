namespace HomeCleaning.RoomService.DTO.Amenities
{
    public class CreateAmenityRequest
    {
        public string Name { get; set; }
    }

    public class AmenityQuantityDto
    {
        public int AmenityId { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
