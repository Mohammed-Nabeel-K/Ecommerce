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
                    { new Guid("28b15d60-4454-487e-a361-0ca6d7cf197d"), "Laptop" },
                    { new Guid("85728bf3-7cf3-4978-9ef1-8c3a7ad15f48"), "Phone" },
                    { new Guid("dde2c829-c9d7-4a73-b556-9966ad33fb4b"), "Books" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "CreatedTime", "Email", "IsBlocked", "Name", "Password", "Roles", "phoneNumber", "username" },
                values: new object[,]
                {
                    { new Guid("c39baa18-00fd-40d0-818a-20523768798d"), new DateTime(2024, 11, 21, 15, 9, 16, 837, DateTimeKind.Local).AddTicks(6943), "nabeel@gmail.com", false, "nabeel", "$2a$11$pReVrGcvw.wu9l4PSIkNFehP9FDb3HI3pspP.bqMv2Coyjjvit/se", "admin", "8129747407", "nabeel" },
                    { new Guid("d339cae1-247f-4ef1-955b-d1a8c0c4edc9"), new DateTime(2024, 11, 21, 15, 9, 16, 675, DateTimeKind.Local).AddTicks(7744), "admin@gmail.com", false, "admin", "$2a$11$iRkftWnTiqJirQMvdVvLleRtka4wZe8QFIbAGDmJccNOai04o57Ei", "admin", "9876543210", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("28b15d60-4454-487e-a361-0ca6d7cf197d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("85728bf3-7cf3-4978-9ef1-8c3a7ad15f48"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "category_id",
                keyValue: new Guid("dde2c829-c9d7-4a73-b556-9966ad33fb4b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("c39baa18-00fd-40d0-818a-20523768798d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "user_id",
                keyValue: new Guid("d339cae1-247f-4ef1-955b-d1a8c0c4edc9"));

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
    }
}
