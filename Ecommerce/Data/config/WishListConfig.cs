using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.config
{
    public class WishListConfig : IEntityTypeConfiguration<WishList>
    {
        public void Configure(EntityTypeBuilder<WishList> builder)
        {
            builder.HasKey(n => n.wishlist_id);

            builder.HasOne(n => n.user)
                .WithMany(n => n.wishList)
                .HasForeignKey( n => n.user_id )
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(n => n.product)
                .WithMany(n => n.wishLists)
                .HasForeignKey(n => n.product_id);

            builder.Property(n => n.wishlist_id)
                .HasDefaultValueSql("NEWID()");


        }

    }
}
