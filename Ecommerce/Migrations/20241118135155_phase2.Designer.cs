﻿// <auto-generated />
using System;
using Ecommerce.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ecommerce.Migrations
{
    [DbContext(typeof(UserDBContext))]
    [Migration("20241118135155_phase2")]
    partial class phase2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                            category_id = new Guid("a8be6d02-7d16-45ca-808c-0f0a7daf4228"),
                            category_name = "Books"
                        },
                        new
                        {
                            category_id = new Guid("ae4a98f0-e05f-4bc0-9f79-aca14503e23e"),
                            category_name = "Phone"
                        },
                        new
                        {
                            category_id = new Guid("9b942484-8872-406f-96ee-ab6e9bdfcf28"),
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
                            user_id = new Guid("0a29f8cb-4ded-49f5-8595-8f9088e24717"),
                            CreatedTime = new DateTime(2024, 11, 18, 19, 21, 54, 918, DateTimeKind.Local).AddTicks(3204),
                            Email = "admin@gmail.com",
                            IsBlocked = false,
                            Name = "admin",
                            Password = "$2a$11$CIJUWN/hQ6SNY37pmeNhw.CFfMj8CBrTyqFXyxtZlh9T09HrLdn7i",
                            Roles = "admin",
                            phoneNumber = "9876543210",
                            username = "admin"
                        },
                        new
                        {
                            user_id = new Guid("91f379a7-d654-49f4-86c0-ce7d69349c87"),
                            CreatedTime = new DateTime(2024, 11, 18, 19, 21, 55, 52, DateTimeKind.Local).AddTicks(8350),
                            Email = "nabeel@gmail.com",
                            IsBlocked = false,
                            Name = "nabeel",
                            Password = "$2a$11$OdsmpO/dTckPm1TDSfM9Z..l0Wp.6d9xWAbCACoVutTJZdm0O.Hyy",
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