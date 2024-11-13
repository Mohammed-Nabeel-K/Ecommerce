namespace Ecommerce.Models
{
    public class Cart
    {
        public int cart_id { get; set; }
        public int user_id { get; set; }


        public User user { get; set; }

        public ICollection<CartItem> cartItem {get;set;}
        

    }
}
