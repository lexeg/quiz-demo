using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using QuizDemo.DataAccess.Contexts;

namespace QuizDemo.DataAccess.Migrations;

public class QuizDbContextFactory : IDesignTimeDbContextFactory<QuizDbContext>
{
    public QuizDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<QuizDbContext>();
        optionsBuilder.UseNpgsql(builder =>
        {
            builder.MigrationsAssembly(typeof(QuizDbContextFactory).Assembly.FullName);
        });
        return new QuizDbContext(optionsBuilder.Options);
    }
}