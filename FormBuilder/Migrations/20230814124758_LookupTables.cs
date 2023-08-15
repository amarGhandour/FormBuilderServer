using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormBuilder.Migrations
{
    /// <inheritdoc />
    public partial class LookupTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LookupId",
                table: "AttributeSchemas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lookups",
                columns: table => new
                {
                    LookupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    relationShipName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentTableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChildTableId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lookups", x => x.LookupId);
                    table.ForeignKey(
                        name: "FK_Lookups_entitySchemas_ParentTableId",
                        column: x => x.ParentTableId,
                        principalTable: "entitySchemas",
                        principalColumn: "EntitySchemaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeSchemas_LookupId",
                table: "AttributeSchemas",
                column: "LookupId");

            migrationBuilder.CreateIndex(
                name: "IX_Lookups_ParentTableId",
                table: "Lookups",
                column: "ParentTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeSchemas_Lookups_LookupId",
                table: "AttributeSchemas",
                column: "LookupId",
                principalTable: "Lookups",
                principalColumn: "LookupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeSchemas_Lookups_LookupId",
                table: "AttributeSchemas");

            migrationBuilder.DropTable(
                name: "Lookups");

            migrationBuilder.DropIndex(
                name: "IX_AttributeSchemas_LookupId",
                table: "AttributeSchemas");

            migrationBuilder.DropColumn(
                name: "LookupId",
                table: "AttributeSchemas");
        }
    }
}
