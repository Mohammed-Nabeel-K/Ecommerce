﻿using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Data.config
{
    public class userConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder) {
            builder.HasData(new List<User>
            {
                new User {
                    user_id = Guid.NewGuid(),
                    username = "admin",
                    Name ="admin",
                    Email = "admin@gmail.com",
                    phoneNumber = "9876543210",
                    Password = BCrypt.Net.BCrypt.HashPassword("adminadm"),
                    Roles = "admin"
                    
                },
                new User {
                    user_id = Guid.NewGuid(),
                    username = "nabeel",
                    Name ="nabeel",
                    Email = "nabeel@gmail.com",
                    phoneNumber = "8129747407",
                    Password = BCrypt.Net.BCrypt.HashPassword("nabeelna"),
                    Roles = "admin"

                },
            });

            builder.HasKey(e => e.user_id);

            builder.Property(e => e.user_id)
                .HasDefaultValueSql("NEWID()");

            builder.HasIndex(e => e.username).IsUnique();

            builder.HasIndex(e => e.Email).IsUnique();

            builder.HasIndex(e => e.phoneNumber).IsUnique();

            
        }
    }
}
