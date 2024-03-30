using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizDemo.DataAccess.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tests_table",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("TestsTable_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "questions_table",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    test_id = table.Column<Guid>(type: "uuid", nullable: false),
                    question = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    answers = table.Column<string>(type: "json", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("questions_table_pkey", x => x.id);
                    table.ForeignKey(
                        name: "questions_table_test_id_fkey",
                        column: x => x.test_id,
                        principalTable: "tests_table",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "test_results_table",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    test_id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    answers = table.Column<string>(type: "json", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("test_results_table_pkey", x => x.id);
                    table.ForeignKey(
                        name: "test_results_table_id_fkey",
                        column: x => x.id,
                        principalTable: "tests_table",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_questions_table_test_id",
                table: "questions_table",
                column: "test_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "questions_table");

            migrationBuilder.DropTable(
                name: "test_results_table");

            migrationBuilder.DropTable(
                name: "tests_table");
        }
    }
}
