namespace Ecommerce.DTOs
{
    public class AddressGetDTO
    {
        public Guid address_id { get; set; }
        public string type { get; set; }
        public string address { get; set; }
        public int pincode { get; set; }
    }
}
