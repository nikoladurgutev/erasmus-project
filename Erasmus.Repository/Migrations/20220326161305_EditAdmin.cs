using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class EditAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12739aa2-fc68-45db-82e8-2d0602e94eb6",
                column: "ConcurrencyStamp",
                value: "5b670f7d-6962-4fe7-929a-3b90e4e08089");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "2de2ed0a-09d4-4408-8b89-e0ebf8822516");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "e47f74ed-b1a2-496d-bec9-59623fe901c6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c76aee55-4ff7-463d-a2ba-ce2c8a06e13b",
                column: "ConcurrencyStamp",
                value: "a40d3933-df87-4580-8375-3571d7e6285f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "f577fb78-c4d4-444d-a20f-f3786ffeaecb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "3855c9af-b436-44cc-845d-766cfbb9514a", "AQAAAAEAACcQAAAAEMUih2vJ6FDnApXeC4LE3811ZSCAIrq8JkoUgDx42uNNtSf10O4DTtMiXzuq1cVTTg==", null, true, "620f3994-0deb-4a05-8ffa-f478056e7089" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12739aa2-fc68-45db-82e8-2d0602e94eb6",
                column: "ConcurrencyStamp",
                value: "0847f649-9f88-4a4f-8a55-462768a64f3f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "d2b5366b-a6a9-41f2-8ea0-e26d4061caa6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "a8a7af0a-b20c-4d53-a58b-fd527ce7265c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c76aee55-4ff7-463d-a2ba-ce2c8a06e13b",
                column: "ConcurrencyStamp",
                value: "a6a9dbc2-527e-44ae-a6bd-b6095b99eff7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "8bcde26d-f033-47d5-8edb-8ef6817af60d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp" },
                values: new object[] { "6a545d93-068a-4471-8a33-6d355200cde7", "AQAAAAEAACcQAAAAENqClP6BZZwKBqI9VtHP4N4CUV6iGftvYUuXKynrRSGNekP6kDPpfK26oSN9nsjCOg==", "1234567890", false, "d65b9eb3-e9e7-48ad-99ea-1c98512f858b" });
        }
    }
}
