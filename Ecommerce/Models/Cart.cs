using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Cart
    {
        [Key]
        public Guid cart_id { get; set; }
        public Guid user_id { get; set; }
        public int cartItemsCount {  get; set; }
        public int total_amount {  get; set; }



        public User user { get; set; }

        public ICollection<CartItem> cartItem {get;set;}
        

    }
}
