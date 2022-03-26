using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class AddClassForUserTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2dec3239-06f4-49ff-851f-e455cd1ca396");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d9f525d-3293-4d16-b7eb-f5c5f80ec558");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bae2bc3-3c1b-497a-b270-7b9ebf983478");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e25d3964-99b7-4b8b-aacd-bc8810d39b14");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e25d3964-99b7-4b8b-aacd-bc8810d39b14", "a85cf70a-8c08-42e3-8e9b-a5cb175baf52", "Student", null },
                    { "2dec3239-06f4-49ff-851f-e455cd1ca396", "a87ef310-f4a0-40d1-99a3-866918e79fe1", "User", null },
                    { "8bae2bc3-3c1b-497a-b270-7b9ebf983478", "f8186467-b395-45d9-bd97-d3261959e15a", "Admin", null },
                    { "3d9f525d-3293-4d16-b7eb-f5c5f80ec558", "43afdc0d-8cf5-4553-b6c2-98736d9aeb95", "Coordinator", null }
                });
        }
    }
}
