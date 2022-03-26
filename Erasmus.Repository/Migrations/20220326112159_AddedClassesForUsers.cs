using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class AddedClassesForUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ea0e88e-a013-43af-8b09-7c1493982e59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d56fb07-e1b4-468b-8b9c-00b14f305669");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d105966b-5761-4c3e-9a9c-784e8263c55b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d964db54-0376-4c97-b124-95d02d322e43");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "AdminId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoordinatorId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ParticipantId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coordinators",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coordinators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "91b4cc57-567c-44cd-9000-e76db18d048b", "76a04d69-5f31-451c-bbbc-7c99dd9fb3f8", "Student", null },
                    { "c1139df5-5923-4725-a4cd-4d5928b2199e", "8ed4d5ee-eb82-44ca-806e-ef8b28dffe4a", "User", null },
                    { "715c83f1-fbae-4b59-b1be-b94670428475", "ecba1604-dcce-43cf-a4d0-a2b4ef40f86f", "Admin", null },
                    { "51e8ec0b-8998-4fdd-85c5-73fd737dabad", "adb66c97-424d-4ec7-8e63-1b1eb84ce049", "Coordinator", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AdminId",
                table: "AspNetUsers",
                column: "AdminId",
                unique: true,
                filter: "[AdminId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CoordinatorId",
                table: "AspNetUsers",
                column: "CoordinatorId",
                unique: true,
                filter: "[CoordinatorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ParticipantId",
                table: "AspNetUsers",
                column: "ParticipantId",
                unique: true,
                filter: "[ParticipantId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StudentId",
                table: "AspNetUsers",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Admins_AdminId",
                table: "AspNetUsers",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Coordinators_CoordinatorId",
                table: "AspNetUsers",
                column: "CoordinatorId",
                principalTable: "Coordinators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Participants_ParticipantId",
                table: "AspNetUsers",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Students_StudentId",
                table: "AspNetUsers",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Admins_AdminId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Coordinators_CoordinatorId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Participants_ParticipantId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Students_StudentId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Coordinators");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AdminId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_CoordinatorId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ParticipantId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StudentId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51e8ec0b-8998-4fdd-85c5-73fd737dabad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "715c83f1-fbae-4b59-b1be-b94670428475");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91b4cc57-567c-44cd-9000-e76db18d048b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1139df5-5923-4725-a4cd-4d5928b2199e");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CoordinatorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d105966b-5761-4c3e-9a9c-784e8263c55b", "0043d35e-cd0d-490c-9bde-0540b5430c4c", "Student", null },
                    { "5ea0e88e-a013-43af-8b09-7c1493982e59", "582caae2-7c7a-4158-818c-fcc6f4b4b6e1", "User", null },
                    { "7d56fb07-e1b4-468b-8b9c-00b14f305669", "ca2bed16-e396-44bb-8c36-0eddfb13ba5f", "Admin", null },
                    { "d964db54-0376-4c97-b124-95d02d322e43", "4ff86220-2431-41ac-b13f-a9bd8c9b9f14", "Coordinator", null }
                });
        }
    }
}
