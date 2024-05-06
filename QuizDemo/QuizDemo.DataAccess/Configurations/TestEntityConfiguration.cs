using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuizDemo.DataAccess.Entities;

namespace QuizDemo.DataAccess.Configurations;

public class TestEntityConfiguration : IEntityTypeConfiguration<TestEntity>
{
    public void Configure(EntityTypeBuilder<TestEntity> builder)
    {
        builder.HasKey(e => e.Id);

        builder.ToTable("tests_table");

        builder.Property(e => e.Id)
            .ValueGeneratedNever()
            .HasColumnName("id");
        builder.Property(e => e.Description)
            .IsRequired()
            .HasMaxLength(1000)
            .HasColumnName("description");
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(150)
            .HasColumnName("name");
    }
}