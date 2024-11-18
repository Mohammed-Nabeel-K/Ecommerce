namespace Ecommerce.DTOs
{
    public class CartItemDTO
    {
        public Guid cartItem_id { get; set; }
        public string product_name {  get; set; }
        public int quantity { get; set; }
        public int price { get; set; }

        
    }
}
