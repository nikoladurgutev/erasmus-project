using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class UpdateAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12739aa2-fc68-45db-82e8-2d0602e94eb6",
                column: "ConcurrencyStamp",
                value: "3ca027b7-0526-4d80-9bbb-2440500ddf3c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "0d1dd5d2-d97d-40ce-ac3a-e4aeea9e6a4e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "757ba970-2488-48a9-8e00-42b6650c7e3f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c76aee55-4ff7-463d-a2ba-ce2c8a06e13b",
                column: "ConcurrencyStamp",
                value: "7e555e05-d76a-48b3-9c30-29ca6aa1fbf4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "d3a922b9-54ec-4afa-95fe-f028dfbcdf49");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ee0d75e0-7848-43ca-b47d-5cdaf6d89eb4", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEMRQb8cE0j/Ts3G47b3snDqVSK7Di85z+pM49V+pHqiqB8UUFZBflvn9FHpue8qoqg==", "f04840c4-be45-437e-a3ef-99bb63c1af4e", "admin@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12739aa2-fc68-45db-82e8-2d0602e94eb6",
                column: "ConcurrencyStamp",
                value: "09157cf6-4ba1-4c2e-bfd2-c607760770b2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "da1d4baa-a60d-4d96-ab1a-d9316ce9b2da");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "e53884d2-98fd-4a03-9c39-77b028d27c47");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c76aee55-4ff7-463d-a2ba-ce2c8a06e13b",
                column: "ConcurrencyStamp",
                value: "1545be00-1412-4274-a122-0a0e3af1e4ec");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "79ce87e8-1d79-4076-b31d-bb6e7ac69ab7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "5c04c97e-7aa9-48ca-bddd-55a6bb952aa6", null, "AQAAAAEAACcQAAAAEIfQAFUaiveLqqNr8ABsA3ungmTDlS9QrUjpnJLv886+8MTLC6yxUuVhMyluHF9lCA==", "c72bddce-b6f0-4742-967b-06a4038ac3a8", "Admin" });
        }
    }
}
