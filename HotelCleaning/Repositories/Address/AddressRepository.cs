using HotelCleaning.Context;
using HotelCleaning.Models.DataModel.Address;
using HotelCleaning.Models.DataModel.Users;
using Microsoft.EntityFrameworkCore;

namespace HotelCleaning.Repositories.Address
{
    public class AddressRepository: IAddressRepository
    {
        private UserDbContext _context;

        public AddressRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<Addresses?> GetByIdAsync(int id)
        {
            return await _context.Address.FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted);
        }

        public async Task<Addresses> AddSync(Addresses address)
        {
            _context.Address.Add(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<List<Addresses>> GetAllAsync()

        {
            return await _context.Address.Where(u => !u.IsDeleted).ToListAsync();
        }
    }
}
