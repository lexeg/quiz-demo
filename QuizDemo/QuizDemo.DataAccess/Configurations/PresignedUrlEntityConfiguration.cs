using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizDemo.DataAccess.Entities;

namespace QuizDemo.DataAccess.Configurations;

public class PresignedUrlEntityConfiguration : IEntityTypeConfiguration<PresignedUrlEntity>
{
    public void Configure(EntityTypeBuilder<PresignedUrlEntity> builder)
    {
        builder.HasKey(e => e.Id).HasName("presigned_url_table_pkey");

        builder.ToTable("presigned_url_table");

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");
        builder.Property(e => e.BranchOfficeId).HasColumnName("branch_office_id");
        builder.Property(e => e.EducationalProgramId).HasColumnName("educational_program_id");
        builder.Property(e => e.ExpiredDate).HasColumnName("expired_date");
        builder.Property(e => e.PresignedUrl)
            .IsRequired()
            .HasMaxLength(300)
            .HasColumnName("presigned_url");
        builder.Property(e => e.TestId).HasColumnName("test_id");

        builder.HasOne(d => d.BranchOffice).WithMany(p => p.PresignedUrls)
            .HasForeignKey(d => d.BranchOfficeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("presigned_url_table_branch_office_id_fkey");

        builder.HasOne(d => d.EducationalProgram).WithMany(p => p.PresignedUrls)
            .HasForeignKey(d => d.EducationalProgramId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("presigned_url_table_educational_program_id_fkey");

        builder.HasOne(d => d.Test).WithMany(p => p.PresignedUrls)
            .HasForeignKey(d => d.TestId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("presigned_url_table_test_id_fkey");
    }
}