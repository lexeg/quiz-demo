using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizDemo.DataAccess.Entities;

namespace QuizDemo.DataAccess.Configurations;

public class QuestionEntityConfiguration : IEntityTypeConfiguration<QuestionEntity>
{
    public void Configure(EntityTypeBuilder<QuestionEntity> builder)
    {
        builder.HasKey(e => e.Id).HasName("questions_table_pkey");

        builder.ToTable("questions_table");

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");
        builder.Property(e => e.Answers)
            .IsRequired()
            .HasColumnType("json")
            .HasColumnName("answers");
        builder.Property(e => e.Question)
            .IsRequired()
            .HasMaxLength(500)
            .HasColumnName("question");
        builder.Property(e => e.TestId).HasColumnName("test_id");

        builder.HasOne(d => d.Test).WithMany(p => p.Questions)
            .HasForeignKey(d => d.TestId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("questions_table_test_id_fkey");
    }
}