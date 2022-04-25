using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class SeedCityAndCountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad897cbd-630a-460c-9b03-3dc2fafe4501");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12739aa2-fc68-45db-82e8-2d0602e94eb6",
                column: "ConcurrencyStamp",
                value: "5eb93516-05e8-43cd-8bb3-1b73871a4bc9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "371c8ae1-a6a7-4ffb-b7e4-1f9ef1f14146");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "a21aff37-b894-4af0-a5cf-2c67195e5596");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c76aee55-4ff7-463d-a2ba-ce2c8a06e13b",
                column: "ConcurrencyStamp",
                value: "93e9e34b-1df8-415b-95ba-584091bc01a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "c5569dcd-ba8b-4b0f-bb80-23003b1e7ddf");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37fe2fb7-034e-4266-ac80-0eabc023447a", "10544146-07e6-4788-8734-ebdd0c9de214", "Organizer", "ORGANIZER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "88b6679c-ff04-425c-8f22-198d8401949a", "AQAAAAEAACcQAAAAEF0538OGCi0/NmZv20DO7j/xrTmrwkxP/wn2O4wFo8Pae9zD3LPZDQFYbGip7mpkLw==", "ff14abf3-f240-4afb-b82e-a6c7b4ba8667" });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("57242f19-0405-494c-b4bc-bdb52a725442"), "Macedonia" },
                    { new Guid("cbec8be4-6325-4b2f-b08e-22d709c27688"), "UK" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { new Guid("415c3843-4bf9-4a21-8696-6781a66204e2"), new Guid("57242f19-0405-494c-b4bc-bdb52a725442"), "Skopje" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37fe2fb7-034e-4266-ac80-0eabc023447a");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: new Guid("415c3843-4bf9-4a21-8696-6781a66204e2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cbec8be4-6325-4b2f-b08e-22d709c27688"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("57242f19-0405-494c-b4bc-bdb52a725442"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12739aa2-fc68-45db-82e8-2d0602e94eb6",
                column: "ConcurrencyStamp",
                value: "537652f4-20e9-4c4e-91c2-22a456866a6b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "36788a07-551b-4de4-a703-b1094b8bf01f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "dad888c3-e1b7-41a2-a3a1-1f19cb9e8ed9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c76aee55-4ff7-463d-a2ba-ce2c8a06e13b",
                column: "ConcurrencyStamp",
                value: "38689355-a438-4ec4-8590-3070052c369d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "1be7c765-d060-43b2-b15a-28118822df2a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ad897cbd-630a-460c-9b03-3dc2fafe4501", "6de42fa1-2fb7-4c3f-ba6e-73849aaa57dc", "Organizer", "ORGANIZER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60a634d0-57ab-42cd-ade0-2a81670b05de", "AQAAAAEAACcQAAAAEOpZQ3aSSyueXaxmnPj7nGfkAYq15U5SzSmgoralrHvsQSqbTJIjPhYhhavChgJWig==", "60f709c5-3af5-4ad1-b188-5481df3773be" });
        }
    }
}
