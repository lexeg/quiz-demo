using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizDemo.DataAccess.Entities;

namespace QuizDemo.DataAccess.Configurations;

public class BranchOfficeEntityConfiguration : IEntityTypeConfiguration<BranchOfficeEntity>
{
    public void Configure(EntityTypeBuilder<BranchOfficeEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("branch_office_table");

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(200)
            .HasColumnName("name");
        builder.Property(e => e.Prefix)
            .IsRequired()
            .HasMaxLength(10)
            .HasColumnName("prefix");
    }
}