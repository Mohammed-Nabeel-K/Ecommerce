using System.ComponentModel.DataAnnotations;

namespace Ecommerce.DTOs
{
    public class UserDTO
    {
        [Required]
        [MinLength(6)]
        public string username { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        
        public string phoneNumber { get; set; }


        [Required]
        [MinLength(8)]
        public string Password { get; set; }


    }
}
