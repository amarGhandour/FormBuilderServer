using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormBuilder.Migrations
{
    /// <inheritdoc />
    public partial class AddOptionSetTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OptionSetValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionSetValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttributeSchemaOptionSetValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttributeSchemaId = table.Column<int>(type: "int", nullable: false),
                    OptionSetValueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeSchemaOptionSetValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeSchemaOptionSetValues_AttributeSchemas_AttributeSchemaId",
                        column: x => x.AttributeSchemaId,
                        principalTable: "AttributeSchemas",
                        principalColumn: "AttributeSchemaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeSchemaOptionSetValues_OptionSetValues_OptionSetValueId",
                        column: x => x.OptionSetValueId,
                        principalTable: "OptionSetValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeSchemaOptionSetValues_AttributeSchemaId",
                table: "AttributeSchemaOptionSetValues",
                column: "AttributeSchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeSchemaOptionSetValues_OptionSetValueId",
                table: "AttributeSchemaOptionSetValues",
                column: "OptionSetValueId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeSchemaOptionSetValues");

            migrationBuilder.DropTable(
                name: "OptionSetValues");
        }
    }
}
