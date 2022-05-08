using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Erasmus.Repository.Migrations
{
    public partial class AddedCityAndCountryTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5c7b4cf-0386-4a3a-acff-ed31f0ba02f5");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "ErasmusProjects");

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "Universities",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CountryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Universities_CityId",
                table: "Universities",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Universities_Cities_CityId",
                table: "Universities",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Universities_Cities_CityId",
                table: "Universities");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Universities_CityId",
                table: "Universities");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad897cbd-630a-460c-9b03-3dc2fafe4501");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Universities");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Universities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "ErasmusProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12739aa2-fc68-45db-82e8-2d0602e94eb6",
                column: "ConcurrencyStamp",
                value: "9b98ebae-6ade-4f05-9e56-d31dd9b688df");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4eb6f781-cba6-4873-ac70-7539916f1a17",
                column: "ConcurrencyStamp",
                value: "8abc57cb-362f-4690-880b-cbdbab892650");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94a5b35b-ef16-434d-b99c-6ecf3c88b40a",
                column: "ConcurrencyStamp",
                value: "19155cc7-d8e8-4533-9b52-4a0a6ab9a16b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c76aee55-4ff7-463d-a2ba-ce2c8a06e13b",
                column: "ConcurrencyStamp",
                value: "538cd46c-24ce-4d83-a145-8c6179332d8c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5057dbb-cb98-476a-8f85-f27d6e6d7ec7",
                column: "ConcurrencyStamp",
                value: "6c2f9e9a-64c9-4305-b54a-b9ba006e9aed");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d5c7b4cf-0386-4a3a-acff-ed31f0ba02f5", "374f4160-82d9-4564-afa6-07bc915c16b2", "Organizer", "ORGANIZER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "39d5fa31-a2f2-4a15-92d1-85270e35ac83", "AQAAAAEAACcQAAAAEEJ23bV+IlPBlhClVnlguL8Du0xoUpbWVfGrM3ior5geCsrXvtgO+WmUCkmnkmGlCg==", "99228c2d-8b32-4b0d-b234-9173d8fc7c42" });
        }
    }
}
