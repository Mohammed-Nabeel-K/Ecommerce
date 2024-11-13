using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class User
    {
        
        public int user_id { get; set; }
        public string username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string phoneNumber { get; set; }
        public string Password { get; set; }
        public string Roles {  get; set; }  

        public Cart cart { get; set; }
    }
}
