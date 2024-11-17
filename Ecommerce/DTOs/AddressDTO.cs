using System.ComponentModel.DataAnnotations;

namespace Ecommerce.DTOs
{
    public class AddressDTO
    {
        [Required]
        public string type { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        [RegularExpression(@"^.{6}$")]
        public int pincode { get; set; }
    }
}
