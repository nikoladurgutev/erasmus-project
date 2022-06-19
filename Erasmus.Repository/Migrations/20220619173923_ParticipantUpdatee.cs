using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class ParticipantUpdatee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Participants_ParticipantId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Participants_ParticipantId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UploadedFiles_Participants_UserId1",
                table: "UploadedFiles");

            migrationBuilder.DropIndex(
                name: "IX_UploadedFiles_UserId1",
                table: "UploadedFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participants",
                table: "Participants");

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

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "UploadedFiles");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Participants");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UploadedFiles",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Participants",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ParticipantId",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ParticipantId",
                table: "Applications",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participants",
                table: "Participants",
                column: "UserId");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "64a8140b-a9a6-4aed-a854-d8563aa61b0e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "186d0130-b15e-4106-82cc-059918f4a4ae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06137ff-e363-4441-a340-569663a0cc0e",
                column: "ConcurrencyStamp",
                value: "0c71a736-e920-4aea-9bb7-dca68fc5b007");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "2d74c9a1-a724-44de-8081-15378dd248a2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "943c6fb0-34db-4ddc-b080-957a9c119964", "AQAAAAEAACcQAAAAEDws57p0n9p3XYHlmLeRJDCw8pJq0ZMFRb6OCt7cnr23IXZtZEbnTz51Z1zdtgzzUQ==", "d85b6a27-42f4-44ea-9533-d36a89d203a4" });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("6345465d-a6a3-4b40-93c8-2847fa0b674e"), "Language Learning" },
                    { new Guid("9bf302dd-0422-4d5c-a49d-8fc9dc4ea936"), "Computer Science Learning" },
                    { new Guid("a8b6fa6e-2bc5-4062-bf86-7de52a9b371d"), "Business and Marketing" },
                    { new Guid("87594b2c-62a5-482f-91d2-e27053775054"), "Politics" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UploadedFiles_UserId",
                table: "UploadedFiles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Participants_ParticipantId",
                table: "Applications",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Participants_ParticipantId",
                table: "AspNetUsers",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedFiles_Participants_UserId",
                table: "UploadedFiles",
                column: "UserId",
                principalTable: "Participants",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Participants_ParticipantId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Participants_ParticipantId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UploadedFiles_Participants_UserId",
                table: "UploadedFiles");

            migrationBuilder.DropIndex(
                name: "IX_UploadedFiles_UserId",
                table: "UploadedFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participants",
                table: "Participants");

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("6345465d-a6a3-4b40-93c8-2847fa0b674e"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("87594b2c-62a5-482f-91d2-e27053775054"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("9bf302dd-0422-4d5c-a49d-8fc9dc4ea936"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("a8b6fa6e-2bc5-4062-bf86-7de52a9b371d"));

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UploadedFiles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "UploadedFiles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Participants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Participants",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ParticipantId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ParticipantId",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participants",
                table: "Participants",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_UploadedFiles_UserId1",
                table: "UploadedFiles",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Participants_ParticipantId",
                table: "Applications",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Participants_ParticipantId",
                table: "AspNetUsers",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedFiles_Participants_UserId1",
                table: "UploadedFiles",
                column: "UserId1",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
