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
                keyValue: new Guid("9b942484-8872-406f-96ee-ab6e9bdfcf28"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("a8be6d02-7d16-45ca-808c-0f0a7daf4228"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("ae4a98f0-e05f-4bc0-9f79-aca14503e23e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("0a29f8cb-4ded-49f5-8595-8f9088e24717"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("91f379a7-d654-49f4-86c0-ce7d69349c87"));

            migrationBuilder.AddColumn<int>(
                name: "amount",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "amount",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "category_id", "category_name" },
                values: new object[,]
                {
                    { new Guid("9b942484-8872-406f-96ee-ab6e9bdfcf28"), "Laptop" },
                    { new Guid("a8be6d02-7d16-45ca-808c-0f0a7daf4228"), "Books" },
                    { new Guid("ae4a98f0-e05f-4bc0-9f79-aca14503e23e"), "Phone" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "CreatedTime", "Email", "IsBlocked", "Name", "Password", "Roles", "phoneNumber", "username" },
                values: new object[,]
                {
                    { new Guid("0a29f8cb-4ded-49f5-8595-8f9088e24717"), new DateTime(2024, 11, 18, 19, 21, 54, 918, DateTimeKind.Local).AddTicks(3204), "admin@gmail.com", false, "admin", "$2a$11$CIJUWN/hQ6SNY37pmeNhw.CFfMj8CBrTyqFXyxtZlh9T09HrLdn7i", "admin", "9876543210", "admin" },
                    { new Guid("91f379a7-d654-49f4-86c0-ce7d69349c87"), new DateTime(2024, 11, 18, 19, 21, 55, 52, DateTimeKind.Local).AddTicks(8350), "nabeel@gmail.com", false, "nabeel", "$2a$11$OdsmpO/dTckPm1TDSfM9Z..l0Wp.6d9xWAbCACoVutTJZdm0O.Hyy", "admin", "8129747407", "nabeel" }
                });
        }
    }
}
