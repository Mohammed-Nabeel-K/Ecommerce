using Ecommerce.Models;

namespace Ecommerce.DTOs
{
    public class ProductDTO
    {
        public string product_name { get; set; }
        public int quantity { get; set; }
        public int price { get; set; }
        public int category_name { get; set; }
        
    }
}
