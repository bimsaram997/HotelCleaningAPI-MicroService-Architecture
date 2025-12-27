namespace HotelCleaning.DTO.Address
{
    public class AddressRequest
    {
        public string Street1 { get; set; }
        public string? Street2 { get; set; }
        public string City { get; set; }
        public int Country { get; set; }
        public int PostalCode { get; set; }
    }
}
