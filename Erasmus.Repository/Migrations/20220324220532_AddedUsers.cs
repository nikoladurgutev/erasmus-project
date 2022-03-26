using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class AddedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6398ffc4-7ff8-4a50-aae6-19f171d4dd58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a6cb36a-31c0-405e-8d9c-6a6a82122fa5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4febcaf-e560-4f75-9efb-14f09b865d8e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f99e7cc4-5de4-42ff-b24d-4f65a69e6f3f");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "6398ffc4-7ff8-4a50-aae6-19f171d4dd58", "ba7935b9-ecae-4c23-a612-20e27a835b89", "Student", null },
                    { "d4febcaf-e560-4f75-9efb-14f09b865d8e", "f29c07cd-8515-4033-9a00-fce33441cc3f", "User", null },
                    { "f99e7cc4-5de4-42ff-b24d-4f65a69e6f3f", "207c4299-9586-405b-9a47-a473659220c3", "Admin", null },
                    { "7a6cb36a-31c0-405e-8d9c-6a6a82122fa5", "87ee762b-5d3f-4695-b2aa-088a17806b4e", "Coordinator", null }
                });
        }
    }
}
