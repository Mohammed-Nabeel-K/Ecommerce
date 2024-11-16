namespace Ecommerce.DTOs
{
    public class ProductGetDTO
    {
        public Guid product_id { get; set; }
        public string product_name { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public string category_name { get; set; }
    }
}
