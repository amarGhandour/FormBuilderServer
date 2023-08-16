using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormBuilder.Migrations
{
    /// <inheritdoc />
    public partial class GlobalSettingsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UrlId",
                table: "AttributeSchemas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GlobalSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalSettings", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeSchemas_UrlId",
                table: "AttributeSchemas",
                column: "UrlId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeSchemas_GlobalSettings_UrlId",
                table: "AttributeSchemas",
                column: "UrlId",
                principalTable: "GlobalSettings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeSchemas_GlobalSettings_UrlId",
                table: "AttributeSchemas");

            migrationBuilder.DropTable(
                name: "GlobalSettings");

            migrationBuilder.DropIndex(
                name: "IX_AttributeSchemas_UrlId",
                table: "AttributeSchemas");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UrlId",
                table: "AttributeSchemas");
        }
    }
}
