﻿using System;
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
                name: "branch_office_table",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    prefix = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("branch_office_table_pkey", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "educational_program_table",
                columns: table => new
                {
                    external_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("educational_program_table_pkey", x => x.external_id);
                });

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
                    branch_office_id = table.Column<Guid>(type: "uuid", nullable: false),
                    educational_program_id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    full_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    mobile_phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    presigned_url = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    expired_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    answers = table.Column<string>(type: "json", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("test_results_table_pkey", x => x.id);
                    table.ForeignKey(
                        name: "test_results_table_branch_office_id_fkey",
                        column: x => x.branch_office_id,
                        principalTable: "branch_office_table",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "test_results_table_educational_program_id_fkey",
                        column: x => x.educational_program_id,
                        principalTable: "educational_program_table",
                        principalColumn: "external_id");
                    table.ForeignKey(
                        name: "test_results_table_id_fkey",
                        column: x => x.test_id,
                        principalTable: "tests_table",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_questions_table_test_id",
                table: "questions_table",
                column: "test_id");

            migrationBuilder.CreateIndex(
                name: "IX_test_results_table_branch_office_id",
                table: "test_results_table",
                column: "branch_office_id");

            migrationBuilder.CreateIndex(
                name: "IX_test_results_table_educational_program_id",
                table: "test_results_table",
                column: "educational_program_id");

            migrationBuilder.CreateIndex(
                name: "IX_test_results_table_test_id",
                table: "test_results_table",
                column: "test_id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "questions_table");

            migrationBuilder.DropTable(
                name: "test_results_table");

            migrationBuilder.DropTable(
                name: "branch_office_table");

            migrationBuilder.DropTable(
                name: "educational_program_table");

            migrationBuilder.DropTable(
                name: "tests_table");
        }
    }
}