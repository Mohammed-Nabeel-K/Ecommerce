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
            migrationBuilder.DropIndex(
                name: "IX_CartItems_product_id",
                table: "CartItems");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("1e78901d-367f-4084-b8f5-7720eeb2515d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("f2776af8-8c2c-4868-b674-bc16b2229c1c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("fae0a5a9-dcc7-4b5f-89a9-ef69de96edc6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("90712ffc-98ea-4b9e-a570-ffb20770bbc6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("e1973c4a-257b-49eb-a52a-9df336d29d07"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "category_id", "category_name" },
                values: new object[,]
                {
                    { new Guid("877bfa35-aed4-42ec-a8e2-8f85b7e9306d"), "Phone" },
                    { new Guid("caea1d05-50f3-4d46-884b-16b5d82862e5"), "Books" },
                    { new Guid("d4e716fa-fc35-41df-842a-d4f33d32e0f6"), "Laptop" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "CreatedTime", "Email", "IsBlocked", "Name", "Password", "Roles", "phoneNumber", "username" },
                values: new object[,]
                {
                    { new Guid("07a56b53-cf93-4c47-b55e-4659d9b41663"), new DateTime(2024, 11, 21, 14, 27, 17, 170, DateTimeKind.Local).AddTicks(4880), "admin@gmail.com", false, "admin", "$2a$11$a2Hmj2x6ZGtj1wpCspefJuoegkVWjjxLPQsK2AVkRqfmFRulMIyTC", "admin", "9876543210", "admin" },
                    { new Guid("ef739014-be1c-4cf5-beda-2318e56a1934"), new DateTime(2024, 11, 21, 14, 27, 17, 318, DateTimeKind.Local).AddTicks(4414), "nabeel@gmail.com", false, "nabeel", "$2a$11$6XDqACMOi3Ni8QBX5Fmle.5tCm/l.X8Xp7MDD69geFbcg5iEj6g1y", "admin", "8129747407", "nabeel" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_product_id",
                table: "CartItems",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CartItems_product_id",
                table: "CartItems");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("877bfa35-aed4-42ec-a8e2-8f85b7e9306d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("caea1d05-50f3-4d46-884b-16b5d82862e5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("d4e716fa-fc35-41df-842a-d4f33d32e0f6"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("07a56b53-cf93-4c47-b55e-4659d9b41663"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("ef739014-be1c-4cf5-beda-2318e56a1934"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "category_id", "category_name" },
                values: new object[,]
                {
                    { new Guid("1e78901d-367f-4084-b8f5-7720eeb2515d"), "Laptop" },
                    { new Guid("f2776af8-8c2c-4868-b674-bc16b2229c1c"), "Phone" },
                    { new Guid("fae0a5a9-dcc7-4b5f-89a9-ef69de96edc6"), "Books" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "CreatedTime", "Email", "IsBlocked", "Name", "Password", "Roles", "phoneNumber", "username" },
                values: new object[,]
                {
                    { new Guid("90712ffc-98ea-4b9e-a570-ffb20770bbc6"), new DateTime(2024, 11, 21, 9, 43, 2, 829, DateTimeKind.Local).AddTicks(6452), "admin@gmail.com", false, "admin", "$2a$11$JkHwrBSIbEX7C1RQrPiFA.x26DrB5y6B36gcu7KUvnxOpFGuOzTny", "admin", "9876543210", "admin" },
                    { new Guid("e1973c4a-257b-49eb-a52a-9df336d29d07"), new DateTime(2024, 11, 21, 9, 43, 2, 971, DateTimeKind.Local).AddTicks(3810), "nabeel@gmail.com", false, "nabeel", "$2a$11$EM2e.EbDYLvt4FN9YMk0q.Gp1h2wnlESqY3ZQbaYk/rMNxNDVRqLi", "admin", "8129747407", "nabeel" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_product_id",
                table: "CartItems",
                column: "product_id",
                unique: true);
        }
    }
}
