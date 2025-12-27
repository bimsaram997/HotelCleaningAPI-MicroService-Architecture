using HomeCleaning.AuthService.DTO.User;
using HotelCleaning.DTO.User;
using HotelCleaning.Models.DataModel;
using HotelCleaning.Models.DataModel.Users;
using HotelCleaning.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HotelCleaning.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly AddressService _addressService;


        public AuthController(AuthService authService, AddressService addressService)
        {
            _authService = authService;
            _addressService = addressService;
        }

        [HttpPost("registerUser")]
        public async Task<IActionResult> Register([FromBody] Registerrequest request)
        {
            
            var registeredUser = await _authService.RegisterAsync(request);

            if (registeredUser == null)
            {
                return BadRequest("User already exists.");
            }

            return Ok(registeredUser);
        }

        [HttpPost("loginUser")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.AuthenticateAsync(request.Email, request.Password);
            if (token == null) return Unauthorized("Invalid credentials");
            return Ok(new { Token = token });
        }

        [Authorize(Policy = "AdminSupervisorOnly")]
        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _authService.GetAllUsersAsync();
            return Ok(users);
        }
    }
}
