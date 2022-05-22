using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class AddFileTypeToFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("0b7c5ef1-3d52-48c9-a300-63286d498c91"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("6893ea1d-d7fd-43c1-b418-127b152d2099"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("7e11f989-e6ca-4fa3-a9ed-1d734feb7afd"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("d6c7f124-273c-4436-bc6d-da58ecc76cf5"));

            migrationBuilder.AddColumn<int>(
                name: "FileType",
                table: "UploadedFiles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "2a2c5f5c-d176-4eca-97d9-764703dc5afd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "b68659a2-4240-4981-9096-691a8a79e9ae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06137ff-e363-4441-a340-569663a0cc0e",
                column: "ConcurrencyStamp",
                value: "5bacc238-0515-4cf2-91a8-76337883627c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "a7b94b77-3985-4be7-8a32-141061f09f64");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "729b35e7-d9a6-4401-9050-25b2315e450c", "AQAAAAEAACcQAAAAEPo9ABsQYieHRxF0N40jTOPD55fFzUt3B4fotJWc61ce1QmGLHqH66ALvG0mdUI70g==", "29cae6c5-8893-4545-b781-2fb012ee92c9" });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("8622dd75-63a5-48ca-bf28-b259a7a41398"), "Language Learning" },
                    { new Guid("81e0db78-1eed-4e24-bc27-580c4a5cdb5a"), "Computer Science Learning" },
                    { new Guid("231adf35-9d04-4db8-9d3f-d3d9ad14950e"), "Business and Marketing" },
                    { new Guid("44d8271f-a85e-4677-b01f-15eca0ac4179"), "Politics" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("231adf35-9d04-4db8-9d3f-d3d9ad14950e"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("44d8271f-a85e-4677-b01f-15eca0ac4179"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("81e0db78-1eed-4e24-bc27-580c4a5cdb5a"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("8622dd75-63a5-48ca-bf28-b259a7a41398"));

            migrationBuilder.DropColumn(
                name: "FileType",
                table: "UploadedFiles");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "dc3a73c3-3757-4a27-9a27-132596e67bd9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "f6cefcea-e058-4432-8c03-b97c10344cfe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06137ff-e363-4441-a340-569663a0cc0e",
                column: "ConcurrencyStamp",
                value: "301bd5ba-c8c7-465a-9680-6684d784d461");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "07c1302a-3b74-4eb2-b17c-572a79ee6582");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f89164d4-5b5d-460a-b6e6-78533e559e9d", "AQAAAAEAACcQAAAAEPzq/JvB6ebs3WEXLXT80YNo6x5smc4MR7tC7Rrq4Ly4qCmbGehSY2tzazNUgDmKtg==", "c15cb1a3-829a-428d-8ed6-a76e9bf94e03" });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("6893ea1d-d7fd-43c1-b418-127b152d2099"), "Language Learning" },
                    { new Guid("d6c7f124-273c-4436-bc6d-da58ecc76cf5"), "Computer Science Learning" },
                    { new Guid("0b7c5ef1-3d52-48c9-a300-63286d498c91"), "Business and Marketing" },
                    { new Guid("7e11f989-e6ca-4fa3-a9ed-1d734feb7afd"), "Politics" }
                });
        }
    }
}
