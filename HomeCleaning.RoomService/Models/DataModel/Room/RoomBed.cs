using HomeCleaning.RoomService.Enums;
using System.Text.Json.Serialization;

namespace HomeCleaning.RoomService.Models.DataModel.Room
{
    public class RoomBed
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        [JsonIgnore] // 👈
        public Room Room { get; set; }

        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public BedType BedType { get; set; }
        public bool IsActive { get; set; } = true;

    }

}
