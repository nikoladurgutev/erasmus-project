using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class ChangedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "de07ff60-ae6d-4fc6-8867-6333c155d4e3", "f9769206-a77e-4675-9bbb-13e1ac7b64cd", "Student", "STUDENT" },
                    { "2b428846-5ef4-46fb-8435-b77412d325f8", "7c484dfc-55f8-46b9-bd26-b31db1d08d22", "User", "USER" },
                    { "0ef6bb47-4cd1-4672-8a8d-74a38c0a2f7d", "e5ccb05f-7c35-4a48-a3d9-95b165b5a12a", "Admin", "ADMIN" },
                    { "57af2b3a-17f0-4313-9892-aeab8b7a32a3", "ed630bc5-491a-4904-8427-106a404a13fb", "Coordinator", "COORDINATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
