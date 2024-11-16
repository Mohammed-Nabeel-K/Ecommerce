using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Product
    {
        [Key]
        public Guid product_id { get; set; }
        public int quantity { get; set; }
        public string product_name { get; set; }
        public int price { get; set; }


        public Guid category_id { get; set; }
        public Category category { get; set; }

        public CartItem cartItem { get; set; }
        public ICollection<Order> order { get; set; }

    }
}
