using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class ChangedRoleNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1017c6c1-9b43-4a80-b867-a6ded6b58045");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "319d2f62-af4e-4ea9-a006-468e8f1cbb7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e2477b9-d7c5-445c-b228-6c3e0bd33b95");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae10cdcf-ffea-458c-a55c-6c34e1c9a75f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4206f286-62ef-4cec-a02f-40ebada4f88d", "87b411de-5d2c-4cd2-b83e-ae2fbe31f519", "STUDENT", null },
                    { "a459e14c-9b12-4063-818b-8200b9df0b71", "38869408-561b-4c1b-b960-1cd7e1d8f14c", "USER", null },
                    { "a089b36a-efed-481c-a5fa-c6bdcad11d18", "415186d4-8a25-4ab5-a94e-3727faada565", "ADMIN", null },
                    { "c746e614-e12d-4751-8551-d3b03b6d18af", "fe8de6ad-520c-499b-bccd-a18cd93af68b", "COORDINATOR", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4206f286-62ef-4cec-a02f-40ebada4f88d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a089b36a-efed-481c-a5fa-c6bdcad11d18");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a459e14c-9b12-4063-818b-8200b9df0b71");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c746e614-e12d-4751-8551-d3b03b6d18af");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "319d2f62-af4e-4ea9-a006-468e8f1cbb7f", "11e82941-b45a-42e0-b41d-8020a7f1c13a", "Student", null },
                    { "1017c6c1-9b43-4a80-b867-a6ded6b58045", "31b858d8-3558-4fa8-afd1-2a0c1986e535", "User", null },
                    { "4e2477b9-d7c5-445c-b228-6c3e0bd33b95", "0b2a077e-2b78-4a2c-abb7-0a4aaf33829b", "Admin", null },
                    { "ae10cdcf-ffea-458c-a55c-6c34e1c9a75f", "d90ab2bb-5c77-4814-9170-2d45626eeca9", "Coordinator", null }
                });
        }
    }
}
