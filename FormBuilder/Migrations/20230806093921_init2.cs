using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormBuilder.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttributeTypes",
                columns: table => new
                {
                    AttributeTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SqlType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeTypes", x => x.AttributeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "EntityFroms",
                columns: table => new
                {
                    EntityFromsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityFromsName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntitySchemaId = table.Column<int>(type: "int", nullable: false),
                    FromJson = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFroms", x => x.EntityFromsId);
                    table.ForeignKey(
                        name: "FK_EntityFroms_entitySchemas_EntitySchemaId",
                        column: x => x.EntitySchemaId,
                        principalTable: "entitySchemas",
                        principalColumn: "EntitySchemaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttributeSchemas",
                columns: table => new
                {
                    AttributeSchemaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntitySchemaId = table.Column<int>(type: "int", nullable: false),
                    LogicalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    MaxLen = table.Column<int>(type: "int", nullable: true),
                    MinLen = table.Column<int>(type: "int", nullable: true),
                    AttributeTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeSchemas", x => x.AttributeSchemaId);
                    table.ForeignKey(
                        name: "FK_AttributeSchemas_AttributeTypes_AttributeTypeId",
                        column: x => x.AttributeTypeId,
                        principalTable: "AttributeTypes",
                        principalColumn: "AttributeTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeSchemas_AttributeTypeId",
                table: "AttributeSchemas",
                column: "AttributeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFroms_EntitySchemaId",
                table: "EntityFroms",
                column: "EntitySchemaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeSchemas");

            migrationBuilder.DropTable(
                name: "EntityFroms");

            migrationBuilder.DropTable(
                name: "AttributeTypes");
        }
    }
}
