using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class UploadedFilesTableChangeUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UploadedFiles_Participants_UserId",
                table: "UploadedFiles");

            migrationBuilder.DropIndex(
                name: "IX_UploadedFiles_UserId",
                table: "UploadedFiles");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UploadedFiles",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "UploadedFiles",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "aacd5d11-ad7a-46ea-8869-9ef6d78be44b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "eeb08c0f-d5b1-4c4a-8d05-98ba99ff749f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06137ff-e363-4441-a340-569663a0cc0e",
                column: "ConcurrencyStamp",
                value: "cb79ae5b-224c-4880-a931-8913dac6bf50");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "c56da101-893a-4fb2-a295-b7d803233a28");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e86445d-e71c-419b-812f-6d0c4ea20f4e", "AQAAAAEAACcQAAAAELoPEGj9mbgsxCmQcspzXYG8fH5GQrT1gJQY8d1BcF7iEYWPzMQDaVmSq5RX8DriMg==", "3c84214b-64a3-4260-9630-58164fc6f45c" });

            migrationBuilder.CreateIndex(
                name: "IX_UploadedFiles_UserId1",
                table: "UploadedFiles",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedFiles_Participants_UserId1",
                table: "UploadedFiles",
                column: "UserId1",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UploadedFiles_Participants_UserId1",
                table: "UploadedFiles");

            migrationBuilder.DropIndex(
                name: "IX_UploadedFiles_UserId1",
                table: "UploadedFiles");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UploadedFiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UploadedFiles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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
    }
}
