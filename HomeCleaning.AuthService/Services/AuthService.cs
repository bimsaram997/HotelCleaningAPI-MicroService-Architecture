using Azure.Core;
using HotelCleaning.DTO.User;
using HotelCleaning.Models.DataModel.Users;
using HotelCleaning.Repositories.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelCleaning.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly AddressService _addressService;

        public AuthService(IUserRepository userRepository,
            IConfiguration configuration,
            AddressService addressService)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _addressService = addressService;
        }

        public async Task<Users?> RegisterAsync(Registerrequest request)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
                return null;

            // 1️⃣ Create Address
            var address = await _addressService.AddAddressAsync(request.Address);
            var user = new Users
            {
                UserCode = Guid.NewGuid().ToString(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                AddedDate = DateTime.UtcNow,
                PhoneNumber = request.PhoneNumber,
                Role = request.Role,
                ImageUrl = request.ImageUrl,
                AddressId = address.Id,
                HashPassword = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };
            return await _userRepository.AddAsync(user);


        }

        public async Task<string?> AuthenticateAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null)
            {
                return null;
            }

            bool valid = BCrypt.Net.BCrypt.Verify(password, user.HashPassword);
            if (!valid)
            {
                return null;
            }


            // Generate JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<Users?> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task<List<Users>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }
    }
}
  
