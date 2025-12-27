using HomeCleaning.RoomService.Models.DataModel.Room;

namespace HomeCleaning.RoomService.Models.DataModel.Amenities
{
    public class Amenity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<RoomAmenity> RoomAmenities { get; set; }
    }
}
