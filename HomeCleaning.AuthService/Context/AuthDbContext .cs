using HotelCleaning.Models.DataModel;
using HotelCleaning.Models.DataModel.Address;
using HotelCleaning.Models.DataModel.Users;
using Microsoft.EntityFrameworkCore;

namespace HotelCleaning.Context
{
    public class AuthDbContext  : DbContext
    {
        public AuthDbContext (DbContextOptions<AuthDbContext > options) : base(options)
        {
        }

        public AuthDbContext ()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            object value = modelBuilder.HasSequence<int>("GRNSequence", schema: "dbo")
            .StartsAt(1)
            .IncrementsBy(1);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Addresses> Address { get; set; }
    }
}
