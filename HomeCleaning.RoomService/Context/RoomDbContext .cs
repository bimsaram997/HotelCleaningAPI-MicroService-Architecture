using HomeCleaning.RoomService.Models.DataModel;
using HomeCleaning.RoomService.Models.DataModel.Amenities;
using HomeCleaning.RoomService.Models.DataModel.Room;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace HotelCleaning.Context
{
    public class RoomDbContext   : DbContext
    {
        public RoomDbContext  (DbContextOptions<RoomDbContext  > options) : base(options)
        {
        }

        public RoomDbContext  ()
        {
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
        public DbSet<RoomBed> RoomBeds { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RoomAmenity>()
                .HasKey(x => new { x.RoomId, x.AmenityId });

            builder.Entity<RoomAmenity>()
            .HasOne(ra => ra.Room)
            .WithMany(r => r.RoomAmenities)
            .HasForeignKey(ra => ra.RoomId);

            builder.Entity<RoomAmenity>()
                .HasOne(ra => ra.Amenity)
                .WithMany(a => a.RoomAmenities)
                .HasForeignKey(ra => ra.AmenityId);

            builder.Entity<RoomBed>()
            .HasOne(rb => rb.Room)
            .WithMany(r => r.Beds)
            .HasForeignKey(rb => rb.RoomId);
        }
    }
}
