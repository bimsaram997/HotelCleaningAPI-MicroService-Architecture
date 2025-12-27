using HotelCleaning.Models.DataModel.Address;
using HotelCleaning.Models.DataModel.Users;

namespace HotelCleaning.Repositories.Address
{
    public interface IAddressRepository
    {
        Task<Addresses?> GetByIdAsync(int id);
        Task<Addresses> AddSync(Addresses address);

        Task<List<Addresses>> GetAllAsync();
    }
}
