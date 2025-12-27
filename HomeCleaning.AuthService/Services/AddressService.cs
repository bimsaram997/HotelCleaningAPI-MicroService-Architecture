using HotelCleaning.DTO;
using HotelCleaning.DTO.Address;
using HotelCleaning.DTO.User;
using HotelCleaning.Models.DataModel;
using HotelCleaning.Models.DataModel.Address;
using HotelCleaning.Repositories;
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

        public async Task<Addresses> AddAddressAsync(AddressRequest request)
        {
            var address = new Addresses
            {
                FullAddress = request.Street1 + " " + request.Street2 + " " + request.PostalCode + " " +
                 request.City + " " + request.City,
                Street1 = request.Street1,
                Street2 = request.Street2,
                City = request.City,
                PostalCode = request.PostalCode,
                Country = request.Country,
                AddedDate = DateTime.UtcNow
            };
            return await _addressRepository.AddSync(address);
        }
    }
}
