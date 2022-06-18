using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class ChangedApplicationIdToNullableField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UploadedFiles_Applications_ApplicationId",
                table: "UploadedFiles");

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("3c9ab040-0758-4d83-8829-0f6a7fb6878f"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("836a6c8b-fc25-4d9b-abc5-0b253edc1e46"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("bac06b00-3a2a-4801-b0a8-69ddaa06e40b"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("c1bb2164-51a0-4df1-bdaa-a6cfeb95fa85"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationId",
                table: "UploadedFiles",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "b836b5ca-b4b3-436b-b828-e81a4ddc7418");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "f754ab0a-3b0d-42f8-9a55-d6b6142a09fe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06137ff-e363-4441-a340-569663a0cc0e",
                column: "ConcurrencyStamp",
                value: "77aca149-be73-491d-af60-4c6820826104");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "0fdd9e4b-cc99-47f6-92df-c5e6b1a31467");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1ca064d-c7b2-4469-b050-233ad883894e", "AQAAAAEAACcQAAAAEFOz4BuBruS0MTG4HGgfZot5CFEByrFv84NcGnI5Q7AVHqwniWKmvJ2Cnm7tXFpsig==", "6c9d959e-a0b0-4b52-bb3c-05fd2c38411e" });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("1857b2fa-e169-4330-b55e-3868c760608f"), "Language Learning" },
                    { new Guid("3ff4ba80-1e81-497a-996a-009c67488837"), "Computer Science Learning" },
                    { new Guid("53178d9e-bd18-46d8-a173-6f0d7591f8bd"), "Business and Marketing" },
                    { new Guid("80d221cf-02d3-4952-bf5f-856d6bbb880a"), "Politics" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedFiles_Applications_ApplicationId",
                table: "UploadedFiles",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UploadedFiles_Applications_ApplicationId",
                table: "UploadedFiles");

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("1857b2fa-e169-4330-b55e-3868c760608f"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("3ff4ba80-1e81-497a-996a-009c67488837"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("53178d9e-bd18-46d8-a173-6f0d7591f8bd"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("80d221cf-02d3-4952-bf5f-856d6bbb880a"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ApplicationId",
                table: "UploadedFiles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "5aeca613-c689-41b7-9723-8c1598eeba7b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "204b4496-66b5-4a7d-a139-cfa1b6dfc471");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06137ff-e363-4441-a340-569663a0cc0e",
                column: "ConcurrencyStamp",
                value: "73b5d39c-d448-4bac-9f0a-f15e7802f277");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "0a1f1c9e-c3d3-438f-84c9-4249303dc506");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2338e655-ca01-48ab-9545-8b8e6fe749b7", "AQAAAAEAACcQAAAAEGmX8brKItGp2mPTgZp7JqVBEpRwGN6TUfSKTdNMycSyLAJlTWPJeQEHjLAT4yFgdw==", "9dd16d37-da0e-4b83-a143-0b6a927df64d" });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("836a6c8b-fc25-4d9b-abc5-0b253edc1e46"), "Language Learning" },
                    { new Guid("c1bb2164-51a0-4df1-bdaa-a6cfeb95fa85"), "Computer Science Learning" },
                    { new Guid("3c9ab040-0758-4d83-8829-0f6a7fb6878f"), "Business and Marketing" },
                    { new Guid("bac06b00-3a2a-4801-b0a8-69ddaa06e40b"), "Politics" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedFiles_Applications_ApplicationId",
                table: "UploadedFiles",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
