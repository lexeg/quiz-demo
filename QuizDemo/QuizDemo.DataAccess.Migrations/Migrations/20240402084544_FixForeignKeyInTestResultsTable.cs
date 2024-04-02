using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizDemo.DataAccess.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeyInTestResultsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "test_results_table_id_fkey",
                table: "test_results_table");

            migrationBuilder.CreateIndex(
                name: "IX_test_results_table_test_id",
                table: "test_results_table",
                column: "test_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "test_results_table_id_fkey",
                table: "test_results_table",
                column: "test_id",
                principalTable: "tests_table",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "test_results_table_id_fkey",
                table: "test_results_table");

            migrationBuilder.DropIndex(
                name: "IX_test_results_table_test_id",
                table: "test_results_table");

            migrationBuilder.AddForeignKey(
                name: "test_results_table_id_fkey",
                table: "test_results_table",
                column: "id",
                principalTable: "tests_table",
                principalColumn: "id");
        }
    }
}
