using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class UploadedFilesTableChangeUserProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UploadedFiles_Participants_CreatedById",
                table: "UploadedFiles");

            migrationBuilder.DropIndex(
                name: "IX_UploadedFiles_CreatedById",
                table: "UploadedFiles");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "UploadedFiles");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "c02dba38-c1ad-411b-bb9c-ab710dc00e4e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "700b4a89-2f0a-44ee-ae30-f69876b530eb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06137ff-e363-4441-a340-569663a0cc0e",
                column: "ConcurrencyStamp",
                value: "22738811-4c0d-41de-bc11-4864e6cbe233");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "abc9d96c-a9dc-44a9-a833-ed0f9ebfe601");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aaa36e7d-c0cf-4844-b56e-03ba99ec9d63", "AQAAAAEAACcQAAAAEAMFFzHTQt3cSoc3aHIItpoj6JF+BP+ham2nqYOb0BpTYE7cqyfo5n81DwWr81frKQ==", "a7c7a411-8844-4f20-969d-6050a1f3da0f" });

            migrationBuilder.CreateIndex(
                name: "IX_UploadedFiles_UserId",
                table: "UploadedFiles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedFiles_Participants_UserId",
                table: "UploadedFiles",
                column: "UserId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UploadedFiles_Participants_UserId",
                table: "UploadedFiles");

            migrationBuilder.DropIndex(
                name: "IX_UploadedFiles_UserId",
                table: "UploadedFiles");

            migrationBuilder.AddColumn<Guid>(
                name: "CreatedById",
                table: "UploadedFiles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "fba1e25a-7dcd-4402-9969-597b947ccede");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "3456d370-f83c-4011-b92b-9e19cd485f8d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06137ff-e363-4441-a340-569663a0cc0e",
                column: "ConcurrencyStamp",
                value: "41706ec4-d926-470d-b4e4-3215543748e2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "291072e1-9049-48d7-b8c2-b61934d2f5e6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abb8d0ec-a150-4054-8651-27be6edf9793", "AQAAAAEAACcQAAAAENDFMh4JYDmzvVjmeHNlJaJb2f2aehMTnIST6XY5a7Ww/43lmKF6xs5NoZ6VBCkJzg==", "061a3dbd-f0f4-4d44-a51c-9993690b158b" });

            migrationBuilder.CreateIndex(
                name: "IX_UploadedFiles_CreatedById",
                table: "UploadedFiles",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedFiles_Participants_CreatedById",
                table: "UploadedFiles",
                column: "CreatedById",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
