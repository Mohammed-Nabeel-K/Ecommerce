using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.config
{
    public class OrderConfig :IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder) {
            builder.HasKey(n => n.order_id);

            builder.Property(n => n.order_id)
                .HasDefaultValueSql("NEWID()");

            builder.HasOne(u => u.product)
                .WithMany(u => u.order)
                .HasForeignKey(u => u.product_id);

            builder.HasOne(u => u.user)
                .WithMany(u => u.orders)
                .HasForeignKey(u => u.user_id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
