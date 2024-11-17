using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class phase6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("5aefa260-ccab-439a-969c-4bd8cad723ff"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("856ef03e-2e70-45a8-9957-2a347eb39337"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("cf3e3385-d8a2-43e4-b642-7ee2cbc25a0d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("c136ede8-a092-4c36-b4d5-bbe33d14db20"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("5aefa260-ccab-439a-969c-4bd8cad723ff"), "Books" },
                    { new Guid("856ef03e-2e70-45a8-9957-2a347eb39337"), "Laptop" },
                    { new Guid("cf3e3385-d8a2-43e4-b642-7ee2cbc25a0d"), "Phone" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "Email", "IsBlocked", "Name", "Password", "Roles", "phoneNumber", "username" },
                values: new object[] { new Guid("c136ede8-a092-4c36-b4d5-bbe33d14db20"), "admin@gmail.com", false, "admin", "admin", "admin", "9876543210", "admin" });
        }
    }
}
