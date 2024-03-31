﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using QuizDemo.DataAccess.Contexts;

#nullable disable

namespace QuizDemo.DataAccess.Migrations.Migrations
{
    [DbContext(typeof(QuizDbContext))]
    [Migration("20240330175624_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("QuizDemo.DataAccess.Entities.QuestionEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Answers")
                        .IsRequired()
                        .HasColumnType("json")
                        .HasColumnName("answers");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("question");

                    b.Property<Guid>("TestId")
                        .HasColumnType("uuid")
                        .HasColumnName("test_id");

                    b.HasKey("Id")
                        .HasName("questions_table_pkey");

                    b.HasIndex("TestId");

                    b.ToTable("questions_table", (string)null);
                });

            modelBuilder.Entity("QuizDemo.DataAccess.Entities.TestEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("TestsTable_pkey");

                    b.ToTable("tests_table", (string)null);
                });

            modelBuilder.Entity("QuizDemo.DataAccess.Entities.TestResultEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Answers")
                        .IsRequired()
                        .HasColumnType("json")
                        .HasColumnName("answers");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<Guid>("TestId")
                        .HasColumnType("uuid")
                        .HasColumnName("test_id");

                    b.HasKey("Id")
                        .HasName("test_results_table_pkey");

                    b.ToTable("test_results_table", (string)null);
                });

            modelBuilder.Entity("QuizDemo.DataAccess.Entities.QuestionEntity", b =>
                {
                    b.HasOne("QuizDemo.DataAccess.Entities.TestEntity", "Test")
                        .WithMany("QuestionsTables")
                        .HasForeignKey("TestId")
                        .IsRequired()
                        .HasConstraintName("questions_table_test_id_fkey");

                    b.Navigation("Test");
                });

            modelBuilder.Entity("QuizDemo.DataAccess.Entities.TestResultEntity", b =>
                {
                    b.HasOne("QuizDemo.DataAccess.Entities.TestEntity", "IdNavigation")
                        .WithOne("TestResultEntity")
                        .HasForeignKey("QuizDemo.DataAccess.Entities.TestResultEntity", "Id")
                        .IsRequired()
                        .HasConstraintName("test_results_table_id_fkey");

                    b.Navigation("IdNavigation");
                });

            modelBuilder.Entity("QuizDemo.DataAccess.Entities.TestEntity", b =>
                {
                    b.Navigation("QuestionsTables");

                    b.Navigation("TestResultEntity");
                });
#pragma warning restore 612, 618
        }
    }
}