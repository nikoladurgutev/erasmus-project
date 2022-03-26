using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class AddRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8357d211-a3c3-4a6d-83f9-b1e8365df29e", "eeb9e5fe-be0c-44d0-8822-1a095e7488e5", "Student", null },
                    { "5d86181f-99a2-4efb-be99-439a48319446", "373d8bf0-f880-4795-91f4-a0c150ec5d53", "User", null },
                    { "e737ad48-4963-4b3b-ba95-cd32e29fd2e5", "d43c8b27-4730-4877-a8d0-3305e027eae1", "Admin", null },
                    { "1866497a-449d-4bf8-a0e8-298e9ba2b5fa", "4aa821f2-6cbe-4327-8c91-cdf72c5cca1c", "Coordinator", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1866497a-449d-4bf8-a0e8-298e9ba2b5fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d86181f-99a2-4efb-be99-439a48319446");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8357d211-a3c3-4a6d-83f9-b1e8365df29e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e737ad48-4963-4b3b-ba95-cd32e29fd2e5");
        }
    }
}
