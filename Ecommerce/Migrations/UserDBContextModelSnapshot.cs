﻿// <auto-generated />
using System;
using Ecommerce.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ecommerce.Migrations
{
    [DbContext(typeof(UserDBContext))]
    partial class UserDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ecommerce.Models.Address", b =>
                {
                    b.Property<Guid>("address_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pincode")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("user_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("address_id");

                    b.HasIndex("user_id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Ecommerce.Models.Cart", b =>
                {
                    b.Property<Guid>("cart_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<int>("cartItemsCount")
                        .HasColumnType("int");

                    b.Property<int>("total_amount")
                        .HasColumnType("int");

                    b.Property<Guid>("user_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("cart_id");

                    b.HasIndex("user_id")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Ecommerce.Models.CartItem", b =>
                {
                    b.Property<Guid>("cartItem_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("cart_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("product_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("cartItem_id");

                    b.HasIndex("cart_id");

                    b.HasIndex("product_id")
                        .IsUnique();

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("Ecommerce.Models.Category", b =>
                {
                    b.Property<Guid>("category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("category_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("category_id");

                    b.HasIndex("category_name")
                        .IsUnique();

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            category_id = new Guid("fae0a5a9-dcc7-4b5f-89a9-ef69de96edc6"),
                            category_name = "Books"
                        },
                        new
                        {
                            category_id = new Guid("f2776af8-8c2c-4868-b674-bc16b2229c1c"),
                            category_name = "Phone"
                        },
                        new
                        {
                            category_id = new Guid("1e78901d-367f-4084-b8f5-7720eeb2515d"),
                            category_name = "Laptop"
                        });
                });

            modelBuilder.Entity("Ecommerce.Models.Order", b =>
                {
                    b.Property<Guid>("order_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("address_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<string>("order_status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("orderplaced")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("product_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("user_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("order_id");

                    b.HasIndex("address_id");

                    b.HasIndex("product_id");

                    b.HasIndex("user_id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Ecommerce.Models.Product", b =>
                {
                    b.Property<Guid>("product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("category_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<string>("product_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("product_id");

                    b.HasIndex("category_id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Ecommerce.Models.User", b =>
                {
                    b.Property<Guid>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("user_id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("phoneNumber")
                        .IsUnique();

                    b.HasIndex("username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            user_id = new Guid("90712ffc-98ea-4b9e-a570-ffb20770bbc6"),
                            CreatedTime = new DateTime(2024, 11, 21, 9, 43, 2, 829, DateTimeKind.Local).AddTicks(6452),
                            Email = "admin@gmail.com",
                            IsBlocked = false,
                            Name = "admin",
                            Password = "$2a$11$JkHwrBSIbEX7C1RQrPiFA.x26DrB5y6B36gcu7KUvnxOpFGuOzTny",
                            Roles = "admin",
                            phoneNumber = "9876543210",
                            username = "admin"
                        },
                        new
                        {
                            user_id = new Guid("e1973c4a-257b-49eb-a52a-9df336d29d07"),
                            CreatedTime = new DateTime(2024, 11, 21, 9, 43, 2, 971, DateTimeKind.Local).AddTicks(3810),
                            Email = "nabeel@gmail.com",
                            IsBlocked = false,
                            Name = "nabeel",
                            Password = "$2a$11$EM2e.EbDYLvt4FN9YMk0q.Gp1h2wnlESqY3ZQbaYk/rMNxNDVRqLi",
                            Roles = "admin",
                            phoneNumber = "8129747407",
                            username = "nabeel"
                        });
                });

            modelBuilder.Entity("Ecommerce.Models.WishList", b =>
                {
                    b.Property<Guid>("wishlist_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("product_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("user_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("wishlist_id");

                    b.HasIndex("user_id");

                    b.ToTable("WishLists");
                });

            modelBuilder.Entity("Ecommerce.Models.Address", b =>
                {
                    b.HasOne("Ecommerce.Models.User", "user")
                        .WithMany("addresses")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Ecommerce.Models.Cart", b =>
                {
                    b.HasOne("Ecommerce.Models.User", "user")
                        .WithOne("cart")
                        .HasForeignKey("Ecommerce.Models.Cart", "user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Ecommerce.Models.CartItem", b =>
                {
                    b.HasOne("Ecommerce.Models.Cart", "cart")
                        .WithMany("cartItem")
                        .HasForeignKey("cart_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommerce.Models.Product", "product")
                        .WithOne("cartItem")
                        .HasForeignKey("Ecommerce.Models.CartItem", "product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cart");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Ecommerce.Models.Order", b =>
                {
                    b.HasOne("Ecommerce.Models.Address", "address")
                        .WithMany("order")
                        .HasForeignKey("address_id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Ecommerce.Models.Product", "product")
                        .WithMany("order")
                        .HasForeignKey("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommerce.Models.User", "user")
                        .WithMany("orders")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("address");

                    b.Navigation("product");

                    b.Navigation("user");
                });

            modelBuilder.Entity("Ecommerce.Models.Product", b =>
                {
                    b.HasOne("Ecommerce.Models.Category", "category")
                        .WithMany("products")
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("Ecommerce.Models.WishList", b =>
                {
                    b.HasOne("Ecommerce.Models.User", "user")
                        .WithMany("wishList")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Ecommerce.Models.Address", b =>
                {
                    b.Navigation("order");
                });

            modelBuilder.Entity("Ecommerce.Models.Cart", b =>
                {
                    b.Navigation("cartItem");
                });

            modelBuilder.Entity("Ecommerce.Models.Category", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("Ecommerce.Models.Product", b =>
                {
                    b.Navigation("cartItem")
                        .IsRequired();

                    b.Navigation("order");
                });

            modelBuilder.Entity("Ecommerce.Models.User", b =>
                {
                    b.Navigation("addresses");

                    b.Navigation("cart")
                        .IsRequired();

                    b.Navigation("orders");

                    b.Navigation("wishList");
                });
#pragma warning restore 612, 618
        }
    }
}
