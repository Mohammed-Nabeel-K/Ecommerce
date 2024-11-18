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
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("1f304d5d-2474-40df-8cd7-a53806d6240c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("2d35b7d7-1e27-4ede-afae-160c9f6cafcf"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("bedf2def-5ff5-48ae-bd45-d895bd6bda05"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("8e50b25c-536c-4371-a0c0-a18cb93d26ff"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("bd9ea528-d584-493d-9c9c-c23cb28ca9fb"));

            migrationBuilder.AlterColumn<string>(
                name: "category_name",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

            migrationBuilder.CreateIndex(
                name: "IX_Categories_category_name",
                table: "Categories",
                column: "category_name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categories_category_name",
                table: "Categories");

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

            migrationBuilder.AlterColumn<string>(
                name: "category_name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "category_id", "category_name" },
                values: new object[,]
                {
                    { new Guid("1f304d5d-2474-40df-8cd7-a53806d6240c"), "Phone" },
                    { new Guid("2d35b7d7-1e27-4ede-afae-160c9f6cafcf"), "Laptop" },
                    { new Guid("bedf2def-5ff5-48ae-bd45-d895bd6bda05"), "Books" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "CreatedTime", "Email", "IsBlocked", "Name", "Password", "Roles", "phoneNumber", "username" },
                values: new object[,]
                {
                    { new Guid("8e50b25c-536c-4371-a0c0-a18cb93d26ff"), new DateTime(2024, 11, 18, 12, 22, 45, 134, DateTimeKind.Local).AddTicks(191), "nabeel@gmail.com", false, "nabeel", "$2a$11$TtDNbzldFeHPm4fLjLB2XuK6xx8o8nMG6twsEiq0d7apwIMZy4a2G", "admin", "8129747407", "nabeel" },
                    { new Guid("bd9ea528-d584-493d-9c9c-c23cb28ca9fb"), new DateTime(2024, 11, 18, 12, 22, 44, 864, DateTimeKind.Local).AddTicks(6678), "admin@gmail.com", false, "admin", "$2a$11$dPDOaYHA259qc3OUW2V/3eL1fnCJAmFIdm5qVZOePaoNcNVsxaW0i", "admin", "9876543210", "admin" }
                });
        }
    }
}
