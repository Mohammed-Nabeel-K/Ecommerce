using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.config
{
    public class cartItemConfig : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder) {
            builder.HasKey(n => n.cartItem_id);

            builder.Property(n => n.cartItem_id)
                .HasDefaultValueSql("NEWID()");

            builder.HasOne(n => n.cart)
                .WithMany(n => n.cartItem)
                .HasForeignKey(n => n.cart_id)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.product)
                .WithMany(u => u.cartItem)
                .HasForeignKey(u => u.product_id);
        }
    }
}
