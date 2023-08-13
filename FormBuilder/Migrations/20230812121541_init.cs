using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormBuilder.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttributeTypes",
                columns: table => new
                {
                    AttributeTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttributeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SqlType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeTypes", x => x.AttributeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "entitySchemas",
                columns: table => new
                {
                    EntitySchemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntityCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entitySchemas", x => x.EntitySchemaId);
                });

            migrationBuilder.CreateTable(
                name: "OptionSets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsGlobal = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntityFroms",
                columns: table => new
                {
                    EntityFromsName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EntitySchemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityFromsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromJson = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFroms", x => new { x.EntitySchemaId, x.EntityFromsName });
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
                    EntitySchemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogicalName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AttributeSchemaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    IsSearchable = table.Column<bool>(type: "bit", nullable: false),
                    MaxLen = table.Column<int>(type: "int", nullable: true),
                    MinLen = table.Column<int>(type: "int", nullable: true),
                    AttributeTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OptionSetTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeSchemas", x => new { x.EntitySchemaId, x.LogicalName });
                    table.ForeignKey(
                        name: "FK_AttributeSchemas_AttributeTypes_AttributeTypeId",
                        column: x => x.AttributeTypeId,
                        principalTable: "AttributeTypes",
                        principalColumn: "AttributeTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttributeSchemas_OptionSets_OptionSetTypeId",
                        column: x => x.OptionSetTypeId,
                        principalTable: "OptionSets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AttributeSchemas_entitySchemas_EntitySchemaId",
                        column: x => x.EntitySchemaId,
                        principalTable: "entitySchemas",
                        principalColumn: "EntitySchemaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OptionSetValues",
                columns: table => new
                {
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OptionSetTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionSetValues", x => new { x.Name, x.Value, x.OptionSetTypeId });
                    table.ForeignKey(
                        name: "FK_OptionSetValues_OptionSets_OptionSetTypeId",
                        column: x => x.OptionSetTypeId,
                        principalTable: "OptionSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttributeSchemas_AttributeTypeId",
                table: "AttributeSchemas",
                column: "AttributeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeSchemas_OptionSetTypeId",
                table: "AttributeSchemas",
                column: "OptionSetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_entitySchemas_EntityName",
                table: "entitySchemas",
                column: "EntityName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OptionSetValues_OptionSetTypeId",
                table: "OptionSetValues",
                column: "OptionSetTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeSchemas");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "EntityFroms");

            migrationBuilder.DropTable(
                name: "OptionSetValues");

            migrationBuilder.DropTable(
                name: "AttributeTypes");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "entitySchemas");

            migrationBuilder.DropTable(
                name: "OptionSets");
        }
    }
}
