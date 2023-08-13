using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormBuilder.Migrations
{
    /// <inheritdoc />
    public partial class edit3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EntityFroms",
                table: "EntityFroms");

            migrationBuilder.AlterColumn<string>(
                name: "EntityFromsName",
                table: "EntityFroms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntityFroms",
                table: "EntityFroms",
                column: "EntityFromsId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFroms_EntitySchemaId",
                table: "EntityFroms",
                column: "EntitySchemaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EntityFroms",
                table: "EntityFroms");

            migrationBuilder.DropIndex(
                name: "IX_EntityFroms_EntitySchemaId",
                table: "EntityFroms");

            migrationBuilder.AlterColumn<string>(
                name: "EntityFromsName",
                table: "EntityFroms",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntityFroms",
                table: "EntityFroms",
                columns: new[] { "EntitySchemaId", "EntityFromsName" });
        }
    }
}
