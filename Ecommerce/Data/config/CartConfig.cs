using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.config
{
    public class CartConfig : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(n => n.cart_id);

            builder.HasOne(n => n.user)
                .WithOne(n => n.cart)
                .HasForeignKey<Cart>(n => n.user_id);
            
            
        }
    }
}
