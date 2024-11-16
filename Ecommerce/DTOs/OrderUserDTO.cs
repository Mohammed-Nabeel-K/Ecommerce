namespace Ecommerce.DTOs
{
    public class OrderUserDTO
    {
        public string product_name { get; set; }
        public DateTime orderplaced { get; set; }
        public string order_status { get; set; }
    }
}
