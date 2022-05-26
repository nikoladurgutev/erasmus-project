using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class ChangedApplicationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UploadedFiles_Applications_ParticipantApplicationId",
                table: "UploadedFiles");

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
                name: "IsApproved",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "IsReviewed",
                table: "Applications");

            migrationBuilder.AddColumn<int>(
                name: "ReviewStatus",
                table: "Applications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "33de60a5-b1d1-44b7-a1f3-d9579790b4d0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "e0e37e6f-600d-410b-96c3-70e33fad892f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a06137ff-e363-4441-a340-569663a0cc0e",
                column: "ConcurrencyStamp",
                value: "0e64d058-3d31-4867-8530-7d63b1731f36");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "06ad77ba-db12-4fb5-bb22-339890f3578b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73b3813c-eace-4bb8-b2a0-717ae023127e", "AQAAAAEAACcQAAAAEBvOv3yko12YIWBVJeKRhFvUXGbTHeAnWwqdDSOIbs5bRX6bwB5co5M/pV9toi8Svw==", "d8d9014f-dec4-4b19-897c-d02b57ce13b7" });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { new Guid("87ee3b82-1de5-49aa-b870-f03eccca7fd1"), "Language Learning" },
                    { new Guid("8d68d029-6fe7-4e6f-b764-5fd1990668c1"), "Computer Science Learning" },
                    { new Guid("d0201044-38ba-4fbc-97ce-c63a64eadda7"), "Business and Marketing" },
                    { new Guid("58cbd70a-ccd0-40ae-8872-512dcd23188b"), "Politics" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("58cbd70a-ccd0-40ae-8872-512dcd23188b"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("87ee3b82-1de5-49aa-b870-f03eccca7fd1"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("8d68d029-6fe7-4e6f-b764-5fd1990668c1"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("d0201044-38ba-4fbc-97ce-c63a64eadda7"));

            migrationBuilder.DropColumn(
                name: "ReviewStatus",
                table: "Applications");

            migrationBuilder.AddColumn<Guid>(
                name: "ParticipantApplicationId",
                table: "UploadedFiles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Applications",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsReviewed",
                table: "Applications",
                type: "bit",
                nullable: true);

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
    }
}
