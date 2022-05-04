using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class AddIdToOrganizerRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "015347fa-d7a2-488d-a9e5-9f13be64a223");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12739aa2-fc68-45db-82e8-2d0602e94eb6",
                column: "ConcurrencyStamp",
                value: "58e9ae5d-7155-4cd9-ba86-da1e441a7968");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "7b2e98b5-9ef9-424f-9780-32524d139712");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "b2301ad8-6bff-4fb8-8b37-3905150b68a5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c76aee55-4ff7-463d-a2ba-ce2c8a06e13b",
                column: "ConcurrencyStamp",
                value: "d001bcad-da93-491f-b49d-17ced5d40274");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "e5c3bb0f-6b60-4eb2-9b92-0bcba5f4619b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a06137ff-e363-4441-a340-569663a0cc0e", "9c44905d-d9af-4786-bd00-532a2e05caea", "Organizer", "ORGANIZER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb25a44e-c23f-46fb-b566-8287b464f4d2", "AQAAAAEAACcQAAAAEImlBDMXoAJOw3MZo1/RSquRM0Z4LrhqKd4/Py+cDDuc32FtqD5doamWaTKPNBAgEw==", "58df7f22-cdc7-4357-a765-eb6886dc59d8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06137ff-e363-4441-a340-569663a0cc0e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12739aa2-fc68-45db-82e8-2d0602e94eb6",
                column: "ConcurrencyStamp",
                value: "e1eebbff-8621-4991-a4e0-d112d0e486f6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "2d297d93-3497-4a72-8a75-99a60803df79");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "0efa2503-09d5-46fb-86d7-607dd3105760");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c76aee55-4ff7-463d-a2ba-ce2c8a06e13b",
                column: "ConcurrencyStamp",
                value: "f2220ab0-7cfa-498e-949c-2b7dae8d6875");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "8e31c64d-1ea1-49f0-a8b5-485824922dce");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "015347fa-d7a2-488d-a9e5-9f13be64a223", "52b0942d-1e2e-4936-8e5e-2675ca8686d2", "Organizer", "ORGANIZER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ab2a51a2-d2e3-4f89-bde0-75c54b615446", "AQAAAAEAACcQAAAAELsrVEtUX4iA9araWqtNW9fAXke3Q3ONTj+vZ587GpoefDnAhk18+ENmpGSCsKaKgQ==", "34e8e38d-1167-49ac-9ea0-0185c561a5f5" });
        }
    }
}
