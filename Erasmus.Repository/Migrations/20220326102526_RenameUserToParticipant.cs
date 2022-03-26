using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class RenameUserToParticipant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35acd28b-8a1f-453d-9eb5-c76a4af2501b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b31a25a-3fe7-48aa-bb09-0d759f731769");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8457cb49-1694-47bd-980e-1fe3b118c962");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b684a449-8385-4f23-89a1-868a84cd1d4c");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b684a449-8385-4f23-89a1-868a84cd1d4c", "594e1833-c12b-46d9-92cb-a0579e1a1c02", "Student", null },
                    { "8457cb49-1694-47bd-980e-1fe3b118c962", "14d166c1-f6f7-4c07-b49c-c3258cc77b73", "User", null },
                    { "4b31a25a-3fe7-48aa-bb09-0d759f731769", "42774141-2fc9-4cf3-a758-6cd03cbfc575", "Admin", null },
                    { "35acd28b-8a1f-453d-9eb5-c76a4af2501b", "79d4b406-aa96-48bb-9d9c-6045ae3cf2fb", "Coordinator", null }
                });
        }
    }
}
