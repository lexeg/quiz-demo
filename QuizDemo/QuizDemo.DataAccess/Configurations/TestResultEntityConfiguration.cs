﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizDemo.DataAccess.Entities;

namespace QuizDemo.DataAccess.Configurations;

public class TestResultEntityConfiguration : IEntityTypeConfiguration<TestResultEntity>
{
    public void Configure(EntityTypeBuilder<TestResultEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("test_results_table");

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");
        builder.Property(e => e.Answers)
            .IsRequired()
            .HasColumnType("json")
            .HasColumnName("answers");
        builder.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("email");
        builder.Property(e => e.FullName)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("full_name");
        builder.Property(e => e.MobilePhone)
            .IsRequired()
            .HasMaxLength(20)
            .HasColumnName("mobile_phone");
        builder.Property(e => e.TestId).HasColumnName("test_id");
        builder.Property(e => e.BranchOfficeId).HasColumnName("branch_office_id");
        builder.Property(e => e.EducationalProgramId).HasColumnName("educational_program_id");

        builder
            .HasOne(d => d.Test)
            .WithOne(p => p.TestResult)
            .HasForeignKey<TestResultEntity>(d => d.TestId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder
            .HasOne(d => d.BranchOffice)
            .WithMany(p => p.TestResults)
            .HasForeignKey(d => d.BranchOfficeId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder
            .HasOne(d => d.EducationalProgram)
            .WithMany(p => p.TestResults)
            .HasForeignKey(d => d.EducationalProgramId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}