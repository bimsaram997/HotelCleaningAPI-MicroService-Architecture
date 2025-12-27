using HotelCleaning.Models.DataModel.Users;

namespace HotelCleaning.Repositories.User
{
    public interface IUserRepository
    {
        Task<Users?> GetByEmailAsync(string email);
        Task<Users> AddAsync(Users user);
        Task<List<Users>> GetAllAsync();
    }
}
