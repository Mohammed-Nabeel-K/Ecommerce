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

            builder.Property(n => n.category_id)
                .HasDefaultValueSql("NEWID()");

            builder.HasIndex(u => u.category_name).IsUnique();

            builder.HasData(new Category()
            {
                category_id = Guid.NewGuid(),
                category_name = "Books"
                
            },
            new Category()
            {
                category_id = Guid.NewGuid(),
                category_name = "Phone"
            },
            new Category()
            {
                category_id = Guid.NewGuid(),
                category_name = "Laptop"
            });
        }
    }
}
