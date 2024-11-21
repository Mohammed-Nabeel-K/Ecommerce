namespace Ecommerce.DTOs
{
    public class WishlistGetDTO
    {
        public Guid wishlist_id { get; set; }
        public string product_name { get; set; }
        public int product_price { get; set; }
    }
}
