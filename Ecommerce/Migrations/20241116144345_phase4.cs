using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class phase4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "category_id", "category_name" },
                values: new object[,]
                {
                    { new Guid("02881b3c-208e-4c4e-87ff-92df12ca6ec4"), "Phone" },
                    { new Guid("ba0d87d0-b388-4818-9ed2-d11abd735150"), "Books" },
                    { new Guid("bfec8c83-e8e8-4c96-ade2-c52f7c2e4c11"), "Laptop" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "Email", "Name", "Password", "Roles", "phoneNumber", "username" },
                values: new object[] { new Guid("a96670fe-a69a-4580-b1a3-a0c293c19b43"), "admin@gmail.com", "admin", "admin", "admin", "9876543210", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("02881b3c-208e-4c4e-87ff-92df12ca6ec4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("ba0d87d0-b388-4818-9ed2-d11abd735150"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("bfec8c83-e8e8-4c96-ade2-c52f7c2e4c11"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("a96670fe-a69a-4580-b1a3-a0c293c19b43"));

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "CartItems");

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
    }
}
