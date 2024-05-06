using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizDemo.DataAccess.Entities;

namespace QuizDemo.DataAccess.Configurations;

public class EducationalProgramEntityConfiguration : IEntityTypeConfiguration<EducationalProgramEntity>
{
    public void Configure(EntityTypeBuilder<EducationalProgramEntity> builder)
    {
        builder.HasKey(e => e.ExternalId);

        builder.ToTable("educational_program_table");

        builder.Property(e => e.ExternalId)
            .ValueGeneratedNever()
            .HasColumnName("external_id");
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100)
            .HasColumnName("name");
    }
}