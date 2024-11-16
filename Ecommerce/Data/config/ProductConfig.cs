using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder) {
            builder.HasKey( n => n.product_id );

            builder.Property(n => n.product_id)
                .HasDefaultValueSql("NEWID()");

            builder.HasOne(n => n.category)
                .WithMany(n => n.products)
                .HasForeignKey(n => n.category_id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
