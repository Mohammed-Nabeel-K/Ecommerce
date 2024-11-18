using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Order
    {
        [Key]
        public Guid order_id { get; set; }
        public string order_status { get; set; }
        public int quantity {  get; set; }  
        public DateTime orderplaced { get; set; } 

        public Guid user_id { get; set; }
        public User user { get; set; }

        public Guid address_id { get; set; }
        public Address address { get; set; }

        public Guid product_id { get; set; }
        public Product product { get; set; }

    }
}
