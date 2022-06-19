using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class AddedTableForProjectFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationId",
                table: "UploadedFiles",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ParticipantId = table.Column<Guid>(nullable: false),
                    NonGovProjectId = table.Column<Guid>(nullable: false),
                    IsReviewed = table.Column<bool>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false),
                    ParticipantApplicationId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_NonGovProject_NonGovProjectId",
                        column: x => x.NonGovProjectId,
                        principalTable: "NonGovProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_Applications_ParticipantApplicationId",
                        column: x => x.ParticipantApplicationId,
                        principalTable: "Applications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Applications_Participants_ParticipantId",
                        column: x => x.ParticipantId,
                        principalTable: "Participants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UploadedFiles_ApplicationId",
                table: "UploadedFiles",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_NonGovProjectId",
                table: "Applications",
                column: "NonGovProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ParticipantApplicationId",
                table: "Applications",
                column: "ParticipantApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ParticipantId",
                table: "Applications",
                column: "ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedFiles_Applications_ApplicationId",
                table: "UploadedFiles",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UploadedFiles_Applications_ApplicationId",
                table: "UploadedFiles");

            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_UploadedFiles_ApplicationId",
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

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                table: "UploadedFiles");

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
        }
    }
}
