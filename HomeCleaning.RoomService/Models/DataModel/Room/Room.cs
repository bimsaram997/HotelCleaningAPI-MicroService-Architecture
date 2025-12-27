using HomeCleaning.RoomService.Enums;

namespace HomeCleaning.RoomService.Models.DataModel.Room
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public int DefaultBedCount { get; set; } = 2;
        public RoomType Type { get; set; }
        public RoomStatus Status { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; } = false;

        public bool HasMilkPackets { get; set; }
        public bool HasCoffeePackets { get; set; }
        public bool HasSugarPackets { get; set; }

        public ICollection<RoomAmenity> RoomAmenities { get; set; } = new List<RoomAmenity>();
        public ICollection<RoomBed> Beds { get; set; }
    }
}
