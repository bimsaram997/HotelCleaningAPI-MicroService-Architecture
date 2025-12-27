using HotelCleaning.Models.DataModel.Users;
using HotelCleaning.Repositories.User;

namespace HotelCleaning.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<Users?> RegisterAsync(Users user, string password)
        {
            var existingUser = await _userRepository.GetByEmailAsync(user.Email);
            if (existingUser != null)
            {
                return null; // User already exists
            }

            user.HashPassword = BCrypt.Net.BCrypt.HashPassword(password);
            user.AddedDate = DateTime.UtcNow;
            return await _userRepository.AddAsync(user);


        }
    }
}
