using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class phase3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "cartItemsCount",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "total_amount",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "category_id", "category_name" },
                values: new object[,]
                {
                    { new Guid("b8ded3f2-14e3-4f69-b160-f64dd88e5cff"), "Laptop" },
                    { new Guid("c196e964-278f-4b59-bb1b-e360edce8257"), "Books" },
                    { new Guid("ca2d1d0b-1094-4745-ac30-7a0d24153882"), "Phone" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "Email", "Name", "Password", "Roles", "phoneNumber", "username" },
                values: new object[] { new Guid("9e6a1ec1-fb89-44e8-a89d-0bf26d4045ba"), "admin@gmail.com", "admin", "admin", "admin", "9876543210", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("b8ded3f2-14e3-4f69-b160-f64dd88e5cff"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("c196e964-278f-4b59-bb1b-e360edce8257"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("ca2d1d0b-1094-4745-ac30-7a0d24153882"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("9e6a1ec1-fb89-44e8-a89d-0bf26d4045ba"));

            migrationBuilder.DropColumn(
                name: "cartItemsCount",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "total_amount",
                table: "Carts");

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
        }
    }
}
