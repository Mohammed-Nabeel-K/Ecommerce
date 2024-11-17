using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class phase7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("0b346cfa-4894-42bd-a0e1-966da0f39147"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("b54b51cf-c509-4887-a846-a0e4e463d0ae"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("ec09a99b-2b24-4485-8d08-ac840f1a80b8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("57d987a6-ac26-46f6-9299-fd66d8496f32"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("9038a617-5a20-49b0-b7d8-488163379a22"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "category_id", "category_name" },
                values: new object[,]
                {
                    { new Guid("08ce98e9-1aa9-47e7-9849-4aaced8c4340"), "Laptop" },
                    { new Guid("2021da11-dab9-49c9-8af4-60565920c432"), "Books" },
                    { new Guid("70490fbb-5862-447f-b3e3-39d546be5e5f"), "Phone" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "Email", "IsBlocked", "Name", "Password", "Roles", "phoneNumber", "username" },
                values: new object[,]
                {
                    { new Guid("e3cda39a-b7dc-4fce-a503-9b510969b862"), "admin@gmail.com", false, "admin", "adminadm", "admin", "9876543210", "admin" },
                    { new Guid("f6113bf1-8efd-415c-b606-879a7e9e4322"), "nabeel@gmail.com", false, "nabeel", "nabeelna", "admin", "9876543210", "nabeel" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("08ce98e9-1aa9-47e7-9849-4aaced8c4340"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("2021da11-dab9-49c9-8af4-60565920c432"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("70490fbb-5862-447f-b3e3-39d546be5e5f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("e3cda39a-b7dc-4fce-a503-9b510969b862"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("f6113bf1-8efd-415c-b606-879a7e9e4322"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "category_id", "category_name" },
                values: new object[,]
                {
                    { new Guid("0b346cfa-4894-42bd-a0e1-966da0f39147"), "Laptop" },
                    { new Guid("b54b51cf-c509-4887-a846-a0e4e463d0ae"), "Books" },
                    { new Guid("ec09a99b-2b24-4485-8d08-ac840f1a80b8"), "Phone" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "Email", "IsBlocked", "Name", "Password", "Roles", "phoneNumber", "username" },
                values: new object[,]
                {
                    { new Guid("57d987a6-ac26-46f6-9299-fd66d8496f32"), "admin@gmail.com", false, "admin", "admina", "admin", "9876543210", "admin" },
                    { new Guid("9038a617-5a20-49b0-b7d8-488163379a22"), "nabeel@gmail.com", false, "nabeel", "nabeel", "admin", "9876543210", "nabeel" }
                });
        }
    }
}
