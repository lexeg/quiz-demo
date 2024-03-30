using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizDemo.DataAccess.Entities;

namespace QuizDemo.DataAccess.Configurations;

public class TestResultEntityConfiguration : IEntityTypeConfiguration<TestResultEntity>
{
    public void Configure(EntityTypeBuilder<TestResultEntity> builder)
    {
        builder.HasKey(e => e.Id).HasName("test_results_table_pkey");

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
        builder.Property(e => e.TestId).HasColumnName("test_id");

        builder.HasOne(d => d.IdNavigation).WithOne(p => p.TestResultEntity)
            .HasForeignKey<TestResultEntity>(d => d.Id)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("test_results_table_id_fkey");
    }
}