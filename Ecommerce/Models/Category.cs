using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Category
    {
        [Key]
        public Guid category_id { get; set; }
        public string category_name { get; set; }
        public ICollection<Product> products { get; set; }
    }
}
