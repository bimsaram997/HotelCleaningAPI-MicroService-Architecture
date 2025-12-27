using HotelCleaning.Context;
using HotelCleaning.Models.DataModel.Users;
using Microsoft.EntityFrameworkCore;

namespace HotelCleaning.Repositories.User
{
    public class UserRepository: IUserRepository
    {
        private UserDbContext _context;
        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task<Users?> GetByEmailAsync(string email) 
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && !u.IsDeleted);
        }

        public async Task<Users> AddAsync(Users user)
        {

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<Users>> GetAllAsync()
        {
            return await _context.Users.Where(u => !u.IsDeleted).ToListAsync();
        }
    }
}
