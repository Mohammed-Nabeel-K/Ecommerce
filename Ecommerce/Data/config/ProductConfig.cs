using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder) {
            builder.HasKey( n => n.product_id );
            builder.HasOne(n => n.category)
                .WithMany(n => n.products)
                .HasForeignKey(n => n.category_id);
            builder.HasData(new Product()
            {
                product_id = 1,
                category_id = 1,
                product_name = "Wings Of Fire",
                price = 300,
                quantity = 50

            },
            new Product()
            {
                product_id = 2,
                category_id = 2,
                product_name = "SAMSUNG",
                price = 30000,
                quantity = 20

            });
        }
    }
}
