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
            migrationBuilder.AddColumn<int>(
                name: "OptionSetTypeId",
                table: "AttributeSchemas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OptionSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsGlobal = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OptionSetValues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionSetTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionSetValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OptionSetValues_OptionSets_OptionSetTypeId",
                        column: x => x.OptionSetTypeId,
                        principalTable: "OptionSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeSchemas_OptionSetTypeId",
                table: "AttributeSchemas",
                column: "OptionSetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OptionSetValues_OptionSetTypeId",
                table: "OptionSetValues",
                column: "OptionSetTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeSchemas_OptionSets_OptionSetTypeId",
                table: "AttributeSchemas",
                column: "OptionSetTypeId",
                principalTable: "OptionSets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeSchemas_OptionSets_OptionSetTypeId",
                table: "AttributeSchemas");

            migrationBuilder.DropTable(
                name: "OptionSetValues");

            migrationBuilder.DropTable(
                name: "OptionSets");

            migrationBuilder.DropIndex(
                name: "IX_AttributeSchemas_OptionSetTypeId",
                table: "AttributeSchemas");

            migrationBuilder.DropColumn(
                name: "OptionSetTypeId",
                table: "AttributeSchemas");
        }
    }
}
