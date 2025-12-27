using HotelCleaning.DTO.Address;

namespace HotelCleaning.DTO.User
{
    public class Registerrequest
    {
        public DateTime AddedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public int Role { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public AddressRequest Address { get; set; }
    }
}
