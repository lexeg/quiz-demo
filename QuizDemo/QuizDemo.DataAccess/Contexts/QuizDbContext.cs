using Microsoft.EntityFrameworkCore;
using QuizDemo.DataAccess.Configurations;
using QuizDemo.DataAccess.Entities;

namespace QuizDemo.DataAccess.Contexts;

public class QuizDbContext : DbContext
{
    public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
    {
    }

    public virtual DbSet<BranchOfficeEntity> BranchOffices { get; set; }

    public virtual DbSet<EducationalProgramEntity> EducationalPrograms { get; set; }

    public virtual DbSet<PresignedUrlEntity> PresignedUrls { get; set; }

    public virtual DbSet<QuestionEntity> Questions { get; set; }

    public virtual DbSet<TestResultEntity> TestResults { get; set; }

    public virtual DbSet<TestEntity> Tests { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new QuestionEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TestResultEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TestEntityConfiguration());
        modelBuilder.ApplyConfiguration(new BranchOfficeEntityConfiguration());
        modelBuilder.ApplyConfiguration(new EducationalProgramEntityConfiguration());
    }
}