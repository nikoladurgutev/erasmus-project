using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class addedImageToNGOEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("58cbd70a-ccd0-40ae-8872-512dcd23188b"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("87ee3b82-1de5-49aa-b870-f03eccca7fd1"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("8d68d029-6fe7-4e6f-b764-5fd1990668c1"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("d0201044-38ba-4fbc-97ce-c63a64eadda7"));

            migrationBuilder.AddColumn<string>(
                name: "ProjectPhotoPath",
                table: "NonGovProject",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "147a40a8-e02a-4a9a-b1c2-79a308eeaddd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "986f9476-37cd-4574-934c-36e4b30c8085");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06137ff-e363-4441-a340-569663a0cc0e",
                column: "ConcurrencyStamp",
                value: "35b4dd6d-5bad-4e32-bed7-8ab708b056b9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "264a7272-1d42-40ae-b5ec-243a7f3cab3c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afcf10e0-3444-427b-90dd-07a1541cb47f", "AQAAAAEAACcQAAAAEI0//6ZXYaFcLn9NmnhsXi8F0reeu/2ElRRWx9ueF/vRdHa23DH+svNJOdEfwkZemQ==", "002493d7-0b75-4785-9bfb-3a5ba01ff9ac" });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("871b7b03-ed85-4008-a4af-15ee050b33a6"), "Language Learning" },
                    { new Guid("bd067875-43ed-479b-879b-c0415e180f7c"), "Computer Science Learning" },
                    { new Guid("4bb3f168-1fa7-457f-98ee-fefaaebe809e"), "Business and Marketing" },
                    { new Guid("057de5f6-6b3c-4468-9242-d716ed3d7173"), "Politics" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("057de5f6-6b3c-4468-9242-d716ed3d7173"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("4bb3f168-1fa7-457f-98ee-fefaaebe809e"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("871b7b03-ed85-4008-a4af-15ee050b33a6"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("bd067875-43ed-479b-879b-c0415e180f7c"));

            migrationBuilder.DropColumn(
                name: "ProjectPhotoPath",
                table: "NonGovProject");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "33de60a5-b1d1-44b7-a1f3-d9579790b4d0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "e0e37e6f-600d-410b-96c3-70e33fad892f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06137ff-e363-4441-a340-569663a0cc0e",
                column: "ConcurrencyStamp",
                value: "0e64d058-3d31-4867-8530-7d63b1731f36");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "06ad77ba-db12-4fb5-bb22-339890f3578b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73b3813c-eace-4bb8-b2a0-717ae023127e", "AQAAAAEAACcQAAAAEBvOv3yko12YIWBVJeKRhFvUXGbTHeAnWwqdDSOIbs5bRX6bwB5co5M/pV9toi8Svw==", "d8d9014f-dec4-4b19-897c-d02b57ce13b7" });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("87ee3b82-1de5-49aa-b870-f03eccca7fd1"), "Language Learning" },
                    { new Guid("8d68d029-6fe7-4e6f-b764-5fd1990668c1"), "Computer Science Learning" },
                    { new Guid("d0201044-38ba-4fbc-97ce-c63a64eadda7"), "Business and Marketing" },
                    { new Guid("58cbd70a-ccd0-40ae-8872-512dcd23188b"), "Politics" }
                });
        }
    }
}
