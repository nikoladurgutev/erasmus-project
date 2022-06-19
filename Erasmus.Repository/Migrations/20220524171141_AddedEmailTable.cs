using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class AddedEmailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Applications_ParticipantApplicationId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_ParticipantApplicationId",
                table: "Applications");

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

            migrationBuilder.DropColumn(
                name: "ParticipantApplicationId",
                table: "Applications");

            migrationBuilder.AddColumn<Guid>(
                name: "ParticipantApplicationId",
                table: "UploadedFiles",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsReviewed",
                table: "Applications",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsApproved",
                table: "Applications",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "ParticipantUserId",
                table: "Applications",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmailMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MailTo = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Sent = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailMessage", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "cb8ed04c-3ac0-4d13-a9c5-91a576232042");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "67a0bc7f-89e0-4dd1-9ebf-ed4189de7cc8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06137ff-e363-4441-a340-569663a0cc0e",
                column: "ConcurrencyStamp",
                value: "808be2f6-c4aa-434b-a23a-336cab9287f5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "bbb2477f-9ab6-4b22-b2a1-7bbfc99a342a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "506c6368-edb4-46e8-bab1-e2fba216194f", "AQAAAAEAACcQAAAAEOuCxqfOYbiGqnA7dtHaNtqPkurVLcl6jQ4krVxwzIVdAX5QoBXxXxiWHYavNgS8fQ==", "61b11165-e6b7-45a5-85a0-09f8e14a136d" });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("878d1649-5f9b-47c0-bef8-abcbd3ca366a"), "Language Learning" },
                    { new Guid("e3f4d178-5f5d-4661-ad3b-915e949556b7"), "Computer Science Learning" },
                    { new Guid("454e9a60-8b87-4024-8dfd-83dbccad1e89"), "Business and Marketing" },
                    { new Guid("192f9820-f7c4-4ecf-b6a5-6a24d24f373d"), "Politics" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UploadedFiles_ParticipantApplicationId",
                table: "UploadedFiles",
                column: "ParticipantApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedFiles_Applications_ParticipantApplicationId",
                table: "UploadedFiles",
                column: "ParticipantApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UploadedFiles_Applications_ParticipantApplicationId",
                table: "UploadedFiles");

            migrationBuilder.DropTable(
                name: "EmailMessage");

            migrationBuilder.DropIndex(
                name: "IX_UploadedFiles_ParticipantApplicationId",
                table: "UploadedFiles");

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("192f9820-f7c4-4ecf-b6a5-6a24d24f373d"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("454e9a60-8b87-4024-8dfd-83dbccad1e89"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("878d1649-5f9b-47c0-bef8-abcbd3ca366a"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("e3f4d178-5f5d-4661-ad3b-915e949556b7"));

            migrationBuilder.DropColumn(
                name: "ParticipantApplicationId",
                table: "UploadedFiles");

            migrationBuilder.DropColumn(
                name: "ParticipantUserId",
                table: "Applications");

            migrationBuilder.AlterColumn<bool>(
                name: "IsReviewed",
                table: "Applications",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsApproved",
                table: "Applications",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ParticipantApplicationId",
                table: "Applications",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ParticipantApplicationId",
                table: "Applications",
                column: "ParticipantApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Applications_ParticipantApplicationId",
                table: "Applications",
                column: "ParticipantApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
