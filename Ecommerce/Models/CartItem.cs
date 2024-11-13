namespace Ecommerce.Models
{
    public class CartItem
    {
        public int cartItem_id { get; set; }

        public int cart_id { get; set; }
        public Cart cart { get; set; }

        public int product_id { get; set; }
        public Product product { get; set; }    



    }
}
