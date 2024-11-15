﻿using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.config
{
    public class cartItemConfig : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder) {
            builder.HasKey(n => n.cartItem_id);

            builder.HasOne(n => n.cart)
                .WithMany(n => n.cartItem)
                .HasForeignKey(n => n.cart_id);
        }
    }
}
