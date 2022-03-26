using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class AllModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Faculties_FacultyId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FacultyId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ef6bb47-4cd1-4672-8a8d-74a38c0a2f7d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b428846-5ef4-46fb-8435-b77412d325f8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "57af2b3a-17f0-4313-9892-aeab8b7a32a3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de07ff60-ae6d-4fc6-8867-6333c155d4e3");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "FacultyId",
                table: "Students",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UniversityId",
                table: "Faculties",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ErasmusProjectId",
                table: "Coordinators",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FacultyId",
                table: "Coordinators",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OrganizerId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ErasmusProjectId",
                table: "Admins",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ErasmusProjectUniversity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UniversityId = table.Column<Guid>(nullable: false),
                    ErasmusProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErasmusProjectUniversity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ErasmusProjectUniversity_ErasmusProjects_ErasmusProjectId",
                        column: x => x.ErasmusProjectId,
                        principalTable: "ErasmusProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ErasmusProjectUniversity_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Organizer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    OrganizationName = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    OrganizationContact = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NonGovProjectOrganizer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrganizerId = table.Column<Guid>(nullable: false),
                    NonGovProjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NonGovProjectOrganizer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NonGovProjectOrganizer_NonGovProject_NonGovProjectId",
                        column: x => x.NonGovProjectId,
                        principalTable: "NonGovProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NonGovProjectOrganizer_Organizer_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Organizer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b9feac3e-6bde-4868-9098-591f4c378167", "e66885a4-b968-4568-9f97-153d347ff609", "Student", "STUDENT" },
                    { "ed705e6e-502a-4698-8b8d-0c070472e66e", "b56cec8a-00d6-4d8f-a55a-b4249cfff9ac", "User", "USER" },
                    { "446ed371-fda8-4b9e-aab2-e9dba6123370", "12862121-51d3-4e3e-a1d4-a5e419704c38", "Admin", "ADMIN" },
                    { "2be820e1-0dcf-4c2e-9dd8-94d5cf3c22b5", "dc843258-b4cc-4799-a7d9-635f84eccb94", "Coordinator", "COORDINATOR" },
                    { "ea1b5e43-51c2-4306-913c-0c606f2f787d", "b7120e76-f1cf-41e9-915c-d9e4ac81d06d", "Organizer", "ORGANIZER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_FacultyId",
                table: "Students",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_UniversityId",
                table: "Faculties",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_Coordinators_ErasmusProjectId",
                table: "Coordinators",
                column: "ErasmusProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Coordinators_FacultyId",
                table: "Coordinators",
                column: "FacultyId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OrganizerId",
                table: "AspNetUsers",
                column: "OrganizerId",
                unique: true,
                filter: "[OrganizerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_ErasmusProjectId",
                table: "Admins",
                column: "ErasmusProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ErasmusProjectUniversity_ErasmusProjectId",
                table: "ErasmusProjectUniversity",
                column: "ErasmusProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ErasmusProjectUniversity_UniversityId",
                table: "ErasmusProjectUniversity",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_NonGovProjectOrganizer_NonGovProjectId",
                table: "NonGovProjectOrganizer",
                column: "NonGovProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_NonGovProjectOrganizer_OrganizerId",
                table: "NonGovProjectOrganizer",
                column: "OrganizerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_ErasmusProjects_ErasmusProjectId",
                table: "Admins",
                column: "ErasmusProjectId",
                principalTable: "ErasmusProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Organizer_OrganizerId",
                table: "AspNetUsers",
                column: "OrganizerId",
                principalTable: "Organizer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinators_ErasmusProjects_ErasmusProjectId",
                table: "Coordinators",
                column: "ErasmusProjectId",
                principalTable: "ErasmusProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinators_Faculties_FacultyId",
                table: "Coordinators",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_Universities_UniversityId",
                table: "Faculties",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Faculties_FacultyId",
                table: "Students",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_ErasmusProjects_ErasmusProjectId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Organizer_OrganizerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Coordinators_ErasmusProjects_ErasmusProjectId",
                table: "Coordinators");

            migrationBuilder.DropForeignKey(
                name: "FK_Coordinators_Faculties_FacultyId",
                table: "Coordinators");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_Universities_UniversityId",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Faculties_FacultyId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "ErasmusProjectUniversity");

            migrationBuilder.DropTable(
                name: "NonGovProjectOrganizer");

            migrationBuilder.DropTable(
                name: "Organizer");

            migrationBuilder.DropIndex(
                name: "IX_Students_FacultyId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_UniversityId",
                table: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_Coordinators_ErasmusProjectId",
                table: "Coordinators");

            migrationBuilder.DropIndex(
                name: "IX_Coordinators_FacultyId",
                table: "Coordinators");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OrganizerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Admins_ErasmusProjectId",
                table: "Admins");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2be820e1-0dcf-4c2e-9dd8-94d5cf3c22b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "446ed371-fda8-4b9e-aab2-e9dba6123370");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9feac3e-6bde-4868-9098-591f4c378167");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea1b5e43-51c2-4306-913c-0c606f2f787d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed705e6e-502a-4698-8b8d-0c070472e66e");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "ErasmusProjectId",
                table: "Coordinators");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Coordinators");

            migrationBuilder.DropColumn(
                name: "OrganizerId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ErasmusProjectId",
                table: "Admins");

            migrationBuilder.AddColumn<Guid>(
                name: "FacultyId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "de07ff60-ae6d-4fc6-8867-6333c155d4e3", "f9769206-a77e-4675-9bbb-13e1ac7b64cd", "Student", "STUDENT" },
                    { "2b428846-5ef4-46fb-8435-b77412d325f8", "7c484dfc-55f8-46b9-bd26-b31db1d08d22", "User", "USER" },
                    { "0ef6bb47-4cd1-4672-8a8d-74a38c0a2f7d", "e5ccb05f-7c35-4a48-a3d9-95b165b5a12a", "Admin", "ADMIN" },
                    { "57af2b3a-17f0-4313-9892-aeab8b7a32a3", "ed630bc5-491a-4904-8427-106a404a13fb", "Coordinator", "COORDINATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FacultyId",
                table: "AspNetUsers",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Faculties_FacultyId",
                table: "AspNetUsers",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
