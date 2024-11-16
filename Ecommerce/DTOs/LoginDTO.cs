using System.ComponentModel.DataAnnotations;

namespace Ecommerce.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string username { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }

    }
}
