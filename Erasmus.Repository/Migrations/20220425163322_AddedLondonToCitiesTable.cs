using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class AddedLondonToCitiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "455acad9-e1ab-424a-b4f5-a33d24903065");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "aa3ecde0-5eea-45d4-8766-b66ed0641e72");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06137ff-e363-4441-a340-569663a0cc0e",
                column: "ConcurrencyStamp",
                value: "8853657f-fa70-41ff-a107-11447d066356");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "b755ddf6-3a40-4ff4-94f8-b48d36604e38");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "53a52af8-83b8-4e7b-a39d-89294e3dbadc", "AQAAAAEAACcQAAAAEKFzHFg1YqoIvOyaStgPNcVL7+v/MEhVRz/jrdLhD6ZOm7Z1UucZjfmWH+p9lRGeJQ==", "4a578420-a53f-42bf-9e55-bbca9c154029" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { new Guid("6c3175f9-55e1-423c-a721-ee2ce7af688c"), new Guid("cbec8be4-6325-4b2f-b08e-22d709c27688"), "London" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("6c3175f9-55e1-423c-a721-ee2ce7af688c"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "94d837fd-50fc-4bbd-8eec-1b4c00d9e9bd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "f90905b9-1fff-48d9-a037-5260b6c49c6e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06137ff-e363-4441-a340-569663a0cc0e",
                column: "ConcurrencyStamp",
                value: "72386f66-3bd2-48aa-89c9-8ee4a0d70ae3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "1be76964-308e-49a6-8a09-24233ecfd2da");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3580a669-7cd2-4d73-851e-9c54a7789573", "AQAAAAEAACcQAAAAEOHBYvQ4vSIOtG5rum3ErlAkBPMHBDSHFKSrncdishFN8nFljmpp2DFZP8Wix+w3rw==", "ba0f6652-977a-429b-843d-aa09833a623e" });
        }
    }
}
