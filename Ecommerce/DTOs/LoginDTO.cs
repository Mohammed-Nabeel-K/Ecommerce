using System.ComponentModel.DataAnnotations;

namespace Ecommerce.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
