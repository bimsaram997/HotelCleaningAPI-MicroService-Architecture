using HotelCleaning.Models.DataModel.Address;
using HotelCleaning.Repositories.Address;

namespace HotelCleaning.Services
{
    public class AddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IConfiguration _configuration;

        public AddressService(IAddressRepository addressRepository, IConfiguration configuration)
        {
            _addressRepository = addressRepository;
            _configuration = configuration;
        }

        public async Task<Addresses> AddAddressAsync(Addresses address)
        {
            address.AddedDate = DateTime.UtcNow;
            return await _addressRepository.AddSync(address);
        }
    }
}
