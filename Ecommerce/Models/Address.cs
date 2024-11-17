namespace Ecommerce.Models
{
    public class Address
    {
        public Guid address_id { get; set; }
        public string type { get; set; }
        public string address {  get; set; }
        public int pincode {  get; set; }

        public Guid user_id { get; set; }
        public User user { get; set; }
    }
}
