using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class User
    {
        [Key]
        public Guid user_id { get; set; }
        public string username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string phoneNumber { get; set; }
        public string Password { get; set; }
        public string Roles { get; set; } = "user";

        public Cart cart { get; set; }
        public ICollection<Order> orders { get; set; }

        public ICollection<WishList> wishList { get; set; }
    }
}
