using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class AddProfilePhotoEntityToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "ProfilePhotoId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProfilePics",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PathOnDisk = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePics", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "514eaeec-efea-44c6-9c99-16684a0d8bd3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "99a4f78a-f465-44d5-88da-ebcdde0731ae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06137ff-e363-4441-a340-569663a0cc0e",
                column: "ConcurrencyStamp",
                value: "78bd8f82-47b8-4efb-86a6-680ef5b2db36");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "2afb8ff6-1d1c-4aff-ae98-038ff2fd506d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "769a7cc1-662a-472d-9e43-32b9e7ee3212", "AQAAAAEAACcQAAAAEH25hK5i9lcnMHLbQTtQ+0xowazSbGeAKU27uOheKsx9fIaTium9QcDS7YSj5GX7Qw==", "ed90dd50-3819-48ab-bcbd-e47b1f2ba2b8" });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("3dc390fa-6677-4f45-8414-8ff89e613b5c"), "Language Learning" },
                    { new Guid("c6ddd5ed-f35f-4634-a56e-3118498901dc"), "Computer Science Learning" },
                    { new Guid("e19c59cf-a2ec-493d-8314-850174947907"), "Business and Marketing" },
                    { new Guid("98e08af1-5d03-4d74-9c01-e70a772173f5"), "Politics" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfilePhotoId",
                table: "AspNetUsers",
                column: "ProfilePhotoId",
                unique: true,
                filter: "[ProfilePhotoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ProfilePics_ProfilePhotoId",
                table: "AspNetUsers",
                column: "ProfilePhotoId",
                principalTable: "ProfilePics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ProfilePics_ProfilePhotoId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ProfilePics");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfilePhotoId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("3dc390fa-6677-4f45-8414-8ff89e613b5c"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("98e08af1-5d03-4d74-9c01-e70a772173f5"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("c6ddd5ed-f35f-4634-a56e-3118498901dc"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("e19c59cf-a2ec-493d-8314-850174947907"));

            migrationBuilder.DropColumn(
                name: "ProfilePhotoId",
                table: "AspNetUsers");

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
    }
}
