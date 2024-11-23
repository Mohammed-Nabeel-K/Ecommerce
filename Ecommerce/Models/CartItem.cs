using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class CartItem
    {
        [Key]
        public Guid cartItem_id { get; set; }

        public Guid cart_id { get; set; }
        public Cart cart { get; set; }
        
        public Guid product_id { get; set; }
        public Product product { get; set; }    

        public int quantity { get; set; }




    }
}
