using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class phase8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("53c70a4f-0c8d-4761-bdfa-44b527e2298a"), "Phone" },
                    { new Guid("6a854aa4-ab95-4730-84f1-a507f411bb84"), "Books" },
                    { new Guid("952541c3-6bb2-43b2-b9cf-211e18b23035"), "Laptop" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "Email", "IsBlocked", "Name", "Password", "Roles", "phoneNumber", "username" },
                values: new object[,]
                {
                    { new Guid("70563f92-8149-4957-b893-beea9e750017"), "nabeel@gmail.com", false, "nabeel", "$2a$11$jt9gg2F7mUf4RngTzaTareEKnRNtR4ix1TlcUeqLSmi3.FdtmHyse", "admin", "9876543210", "nabeel" },
                    { new Guid("d88391f0-b809-4046-83c7-4df87624abfc"), "admin@gmail.com", false, "admin", "$2a$11$5pdkyu80I9hCXX93i4/nA.i4TnJOrvojqWB4098iyqjEyDy9b9XS6", "admin", "9876543210", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("53c70a4f-0c8d-4761-bdfa-44b527e2298a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("6a854aa4-ab95-4730-84f1-a507f411bb84"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("952541c3-6bb2-43b2-b9cf-211e18b23035"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("70563f92-8149-4957-b893-beea9e750017"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("d88391f0-b809-4046-83c7-4df87624abfc"));

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
    }
}
