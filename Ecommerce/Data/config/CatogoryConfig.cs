using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.config
{
    public class CatogoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(n => n.category_id);
            builder.HasData(new Category()
            {
                category_id = 1,
                category_name = "Books"
                
            },
            new Category()
            {
                category_id = 2,
                category_name = "Phone"
            },
            new Category()
            {
                category_id = 3,
                category_name = "Laptop"
            });
        }
    }
}
