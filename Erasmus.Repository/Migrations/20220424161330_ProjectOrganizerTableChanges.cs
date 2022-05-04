using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class ProjectOrganizerTableChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Organizer_OrganizerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_NonGovProjectOrganizer_Organizer_OrganizerId",
                table: "NonGovProjectOrganizer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizer",
                table: "Organizer");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Organizer");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Organizer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrganizerId",
                table: "NonGovProjectOrganizer",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OrganizerId",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizer",
                table: "Organizer",
                column: "UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Organizer_OrganizerId",
                table: "AspNetUsers",
                column: "OrganizerId",
                principalTable: "Organizer",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NonGovProjectOrganizer_Organizer_OrganizerId",
                table: "NonGovProjectOrganizer",
                column: "OrganizerId",
                principalTable: "Organizer",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Organizer_OrganizerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_NonGovProjectOrganizer_Organizer_OrganizerId",
                table: "NonGovProjectOrganizer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizer",
                table: "Organizer");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Organizer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Organizer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganizerId",
                table: "NonGovProjectOrganizer",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "OrganizerId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizer",
                table: "Organizer",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "581715a3-1b13-43cd-a031-5ab4c52b4b7c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "e9bd2888-1e3e-41b0-b2b1-f419cfb2d27b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06137ff-e363-4441-a340-569663a0cc0e",
                column: "ConcurrencyStamp",
                value: "62084df0-1338-4fda-97af-398cfcdfd4bb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "76f66fa8-f9ad-45cc-a344-cf0bd84fad40");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a6fa262-9ea9-437e-9cb4-2fe15b841581", "AQAAAAEAACcQAAAAEJ3hJuTMIoJTuRZZ0q64JZccAvCbTvKSUU5ODN7UQFPj9OeLe88PCDRmMXv6ptJ+cQ==", "4fae3548-6c96-4005-a4bb-fdc4c8552298" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Organizer_OrganizerId",
                table: "AspNetUsers",
                column: "OrganizerId",
                principalTable: "Organizer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NonGovProjectOrganizer_Organizer_OrganizerId",
                table: "NonGovProjectOrganizer",
                column: "OrganizerId",
                principalTable: "Organizer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
