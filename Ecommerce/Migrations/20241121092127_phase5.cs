using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Migrations
{
    /// <inheritdoc />
    public partial class phase5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "amount",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "category_id", "category_name" },
                values: new object[,]
                {
                    { new Guid("770dbde3-6ae2-4341-924f-00e0411d3af6"), "Laptop" },
                    { new Guid("e22bdb6c-7f42-49c1-89ff-7d9e95edf915"), "Phone" },
                    { new Guid("f34981a3-40b5-44c5-9fd7-9f61cab42297"), "Books" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "CreatedTime", "Email", "IsBlocked", "Name", "Password", "Roles", "phoneNumber", "username" },
                values: new object[,]
                {
                    { new Guid("b117f77f-b91e-4bb3-a3af-31bbee9b9686"), new DateTime(2024, 11, 21, 14, 51, 26, 411, DateTimeKind.Local).AddTicks(7841), "admin@gmail.com", false, "admin", "$2a$11$OaAptMlDG2dWS777RZp9ueDJMoiYrrV6pzDOjuJ2rALQjdEIt/8Ei", "admin", "9876543210", "admin" },
                    { new Guid("b8d4a43a-0625-4c7c-b265-6770371567cb"), new DateTime(2024, 11, 21, 14, 51, 26, 563, DateTimeKind.Local).AddTicks(5845), "nabeel@gmail.com", false, "nabeel", "$2a$11$6IDFjZeOJOD1NdTxzCdZ3um4Pr0NhIEYfT3avPyxx.IkGlrcLKGK6", "admin", "8129747407", "nabeel" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("770dbde3-6ae2-4341-924f-00e0411d3af6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("e22bdb6c-7f42-49c1-89ff-7d9e95edf915"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("f34981a3-40b5-44c5-9fd7-9f61cab42297"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("b117f77f-b91e-4bb3-a3af-31bbee9b9686"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("b8d4a43a-0625-4c7c-b265-6770371567cb"));

            migrationBuilder.DropColumn(
                name: "amount",
                table: "CartItems");

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
        }
    }
}
