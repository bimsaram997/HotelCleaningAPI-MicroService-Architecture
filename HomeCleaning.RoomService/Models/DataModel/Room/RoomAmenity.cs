using HomeCleaning.RoomService.Models.DataModel.Amenities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HomeCleaning.RoomService.Models.DataModel.Room
{
    public class RoomAmenity
    {
        public int RoomId { get; set; }
        [JsonIgnore] // 👈
        public Room Room { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }


        public int AmenityId { get; set; }
        public Amenity Amenity { get; set; }
        // Quantity of this amenity in the room
        [Range(1, 100)]
        public int Quantity { get; set; } = 1;
    }
}