namespace Ecommerce.Models
{
    public class Product
    {
        public int product_id { get; set; }
        public int quantity { get; set; }
        public string product_name { get; set; }
        public int price { get; set; }


        public int category_id { get; set; }
        public Category category { get; set; }



    }
}
