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

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    address_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pincode = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.address_id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_user_id",
                table: "Addresses",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

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

            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "Users");

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
    }
}
