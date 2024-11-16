using Ecommerce.Models;

namespace Ecommerce.DTOs
{
    public class OrderAdminDTO
    {
        public Guid order_id { get; set; }
        public string order_status { get; set; }
        public DateTime orderplaced { get; set; }

        public Guid user_id { get; set; }
        public string username { get; set; }

        public string product_name {get;set;}
        
    }
}
