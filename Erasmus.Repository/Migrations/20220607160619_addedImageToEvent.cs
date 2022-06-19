using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class addedImageToEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "095d5bce-4041-4648-b61d-58c41286e2c5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "5ec0a918-0048-4664-9836-e856ce6d1f49");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06137ff-e363-4441-a340-569663a0cc0e",
                column: "ConcurrencyStamp",
                value: "e824acfd-eb50-4cbe-b82f-e12c66cd0a13");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "9d2aa1b5-8021-42d9-9469-f3bd28362314");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "def17fc8-fccf-4dc0-a528-3112ecd47a57", "AQAAAAEAACcQAAAAEJ8+16kdSyoTzRCJIPhoUMPlu4whltopQLWdrDt+yayR0A2IsfD4qTJ0rItS56/RSQ==", "82f784e7-69bf-4454-914b-c7d37b95a22a" });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("c1e3b0e7-be46-4d1b-a8d4-036ca14d1f7b"), "Language Learning" },
                    { new Guid("94471ce4-e80b-46e6-95ab-609be06e4d33"), "Computer Science Learning" },
                    { new Guid("b31ef18a-7bb0-41a6-917a-4a4c0f33a733"), "Business and Marketing" },
                    { new Guid("80eb5256-1be1-4d87-a7bb-f45575a9346f"), "Politics" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("80eb5256-1be1-4d87-a7bb-f45575a9346f"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("94471ce4-e80b-46e6-95ab-609be06e4d33"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("b31ef18a-7bb0-41a6-917a-4a4c0f33a733"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("c1e3b0e7-be46-4d1b-a8d4-036ca14d1f7b"));

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
    }
}
