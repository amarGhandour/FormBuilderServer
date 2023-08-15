using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormBuilder.Migrations
{
    /// <inheritdoc />
    public partial class AddEntityViews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntityViews",
                columns: table => new
                {
                    EntityViewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntitySchemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityViews", x => x.EntityViewId);
                    table.ForeignKey(
                        name: "FK_EntityViews_entitySchemas_EntitySchemaId",
                        column: x => x.EntitySchemaId,
                        principalTable: "entitySchemas",
                        principalColumn: "EntitySchemaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityViews_EntitySchemaId",
                table: "EntityViews",
                column: "EntitySchemaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityViews");
        }
    }
}
