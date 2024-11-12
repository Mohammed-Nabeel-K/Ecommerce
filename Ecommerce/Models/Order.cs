namespace Ecommerce.Models
{
    public class Order
    {
        public int order_id { get; set; }
        public string order_status { get; set; }
        public DateTime orderplaced { get; set; }

        public int user_id { get; set; }
        public User user { get; set; }


        public int product_id { get; set; }
        public Product product { get; set; }

    }
}
