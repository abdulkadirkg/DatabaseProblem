using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NpgsqlTypes;

#nullable disable

namespace NpgsqlProblem.Migrations
{
    /// <inheritdoc />
    public partial class INIT : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DummyDataClasses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Field1 = table.Column<string>(type: "text", nullable: false),
                    Field2 = table.Column<string>(type: "text", nullable: false),
                    Field3 = table.Column<string>(type: "text", nullable: false),
                    FieldInt = table.Column<int>(type: "integer", nullable: false),
                    FieldBool = table.Column<bool>(type: "boolean", nullable: false),
                    SearchVector = table.Column<NpgsqlTsVector>(type: "tsvector", nullable: false)
                        .Annotation("Npgsql:TsVectorConfig", "turkish")
                        .Annotation("Npgsql:TsVectorProperties", new[] { "Field1", "Field2", "Field3" })
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DummyDataClasses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DummyDataClasses_SearchVector",
                table: "DummyDataClasses",
                column: "SearchVector")
                .Annotation("Npgsql:IndexMethod", "GIN");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DummyDataClasses");
        }
    }
}
