using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Models
{
    public class WishList
    {

        [Key]
        
        public Guid wishlist_id { get; set; }

        public Guid user_id {  get; set; }

        public Guid product_id {  get; set; }
        public User user { get; set; }
    }
}
