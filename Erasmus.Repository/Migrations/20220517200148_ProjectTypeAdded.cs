using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class ProjectTypeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectType",
                table: "NonGovProject");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectTypeId",
                table: "NonGovProject",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectType",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectType", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_NonGovProject_ProjectTypeId",
                table: "NonGovProject",
                column: "ProjectTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_NonGovProject_ProjectType_ProjectTypeId",
                table: "NonGovProject",
                column: "ProjectTypeId",
                principalTable: "ProjectType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NonGovProject_ProjectType_ProjectTypeId",
                table: "NonGovProject");

            migrationBuilder.DropTable(
                name: "ProjectType");

            migrationBuilder.DropIndex(
                name: "IX_NonGovProject_ProjectTypeId",
                table: "NonGovProject");

            migrationBuilder.DropColumn(
                name: "ProjectTypeId",
                table: "NonGovProject");

            migrationBuilder.AddColumn<string>(
                name: "ProjectType",
                table: "NonGovProject",
                type: "nvarchar(max)",
                nullable: true);

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
        }
    }
}
