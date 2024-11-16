using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class phase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_Users_wishlist_id",
                table: "WishLists");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("2e4a5156-68f2-455a-946b-7ed2593b9b92"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("462ea5fb-3073-406c-af75-82bf03532f75"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("9d28d83d-38fd-4f39-8f0c-0226cbe8884c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("68bf6fd8-33a9-4c5e-8a1e-a9da8cc63b50"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "category_id", "category_name" },
                values: new object[,]
                {
                    { new Guid("0b99656e-1731-48fb-b8e6-53bca008d883"), "Laptop" },
                    { new Guid("d2e3b5df-d459-4695-b450-174690e31448"), "Phone" },
                    { new Guid("fec5e67b-772e-4ea9-8562-3fcf8933d70c"), "Books" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "Email", "Name", "Password", "Roles", "phoneNumber", "username" },
                values: new object[] { new Guid("4027e3f6-0120-4c54-b5be-8487fcb3e468"), "admin@gmail.com", "admin", "admin", "admin", "9876543210", "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_user_id",
                table: "WishLists",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_Users_user_id",
                table: "WishLists",
                column: "user_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WishLists_Users_user_id",
                table: "WishLists");

            migrationBuilder.DropIndex(
                name: "IX_WishLists_user_id",
                table: "WishLists");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("0b99656e-1731-48fb-b8e6-53bca008d883"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("d2e3b5df-d459-4695-b450-174690e31448"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("fec5e67b-772e-4ea9-8562-3fcf8933d70c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("4027e3f6-0120-4c54-b5be-8487fcb3e468"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "category_id", "category_name" },
                values: new object[,]
                {
                    { new Guid("2e4a5156-68f2-455a-946b-7ed2593b9b92"), "Laptop" },
                    { new Guid("462ea5fb-3073-406c-af75-82bf03532f75"), "Phone" },
                    { new Guid("9d28d83d-38fd-4f39-8f0c-0226cbe8884c"), "Books" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "Email", "Name", "Password", "Roles", "phoneNumber", "username" },
                values: new object[] { new Guid("68bf6fd8-33a9-4c5e-8a1e-a9da8cc63b50"), "admin@gmail.com", "admin", "admin", "admin", "9876543210", "admin" });

            migrationBuilder.AddForeignKey(
                name: "FK_WishLists_Users_wishlist_id",
                table: "WishLists",
                column: "wishlist_id",
                principalTable: "Users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
