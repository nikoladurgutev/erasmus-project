using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class DeletedStudentAndCoordinatorRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12739aa2-fc68-45db-82e8-2d0602e94eb6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c76aee55-4ff7-463d-a2ba-ce2c8a06e13b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "581715a3-1b13-43cd-a031-5ab4c52b4b7c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "e9bd2888-1e3e-41b0-b2b1-f419cfb2d27b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06137ff-e363-4441-a340-569663a0cc0e",
                column: "ConcurrencyStamp",
                value: "62084df0-1338-4fda-97af-398cfcdfd4bb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "76f66fa8-f9ad-45cc-a344-cf0bd84fad40");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a6fa262-9ea9-437e-9cb4-2fe15b841581", "AQAAAAEAACcQAAAAEJ3hJuTMIoJTuRZZ0q64JZccAvCbTvKSUU5ODN7UQFPj9OeLe88PCDRmMXv6ptJ+cQ==", "4fae3548-6c96-4005-a4bb-fdc4c8552298" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                keyValue: "a06137ff-e363-4441-a340-569663a0cc0e",
                column: "ConcurrencyStamp",
                value: "9c44905d-d9af-4786-bd00-532a2e05caea");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "e5c3bb0f-6b60-4eb2-9b92-0bcba5f4619b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c76aee55-4ff7-463d-a2ba-ce2c8a06e13b", "d001bcad-da93-491f-b49d-17ced5d40274", "Student", "STUDENT" },
                    { "12739aa2-fc68-45db-82e8-2d0602e94eb6", "58e9ae5d-7155-4cd9-ba86-da1e441a7968", "Coordinator", "COORDINATOR" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb25a44e-c23f-46fb-b566-8287b464f4d2", "AQAAAAEAACcQAAAAEImlBDMXoAJOw3MZo1/RSquRM0Z4LrhqKd4/Py+cDDuc32FtqD5doamWaTKPNBAgEw==", "58df7f22-cdc7-4357-a765-eb6886dc59d8" });
        }
    }
}
