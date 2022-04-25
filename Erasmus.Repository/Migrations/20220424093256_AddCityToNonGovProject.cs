using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class AddCityToNonGovProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37fe2fb7-034e-4266-ac80-0eabc023447a");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "NonGovProject");

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "NonGovProject",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_NonGovProject_CityId",
                table: "NonGovProject",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_NonGovProject_Cities_CityId",
                table: "NonGovProject",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NonGovProject_Cities_CityId",
                table: "NonGovProject");

            migrationBuilder.DropIndex(
                name: "IX_NonGovProject_CityId",
                table: "NonGovProject");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "015347fa-d7a2-488d-a9e5-9f13be64a223");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "NonGovProject");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "NonGovProject",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12739aa2-fc68-45db-82e8-2d0602e94eb6",
                column: "ConcurrencyStamp",
                value: "5eb93516-05e8-43cd-8bb3-1b73871a4bc9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "371c8ae1-a6a7-4ffb-b7e4-1f9ef1f14146");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "a21aff37-b894-4af0-a5cf-2c67195e5596");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c76aee55-4ff7-463d-a2ba-ce2c8a06e13b",
                column: "ConcurrencyStamp",
                value: "93e9e34b-1df8-415b-95ba-584091bc01a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "c5569dcd-ba8b-4b0f-bb80-23003b1e7ddf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37fe2fb7-034e-4266-ac80-0eabc023447a", "10544146-07e6-4788-8734-ebdd0c9de214", "Organizer", "ORGANIZER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88b6679c-ff04-425c-8f22-198d8401949a", "AQAAAAEAACcQAAAAEF0538OGCi0/NmZv20DO7j/xrTmrwkxP/wn2O4wFo8Pae9zD3LPZDQFYbGip7mpkLw==", "ff14abf3-f240-4afb-b82e-a6c7b4ba8667" });
        }
    }
}
