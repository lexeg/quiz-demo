using System.Reflection;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using QuizDemo.Configuration;
using QuizDemo.DataAccess.Contexts;
using QuizDemo.DataAccess.Repositories;
using QuizDemo.Filters;
using QuizDemo.Services;

namespace QuizDemo;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddDbContext<QuizDbContext>(optionsBuilder =>
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection")));

        services.AddSingleton(
            _ => new MapperConfiguration(cfg => { cfg.AddProfile(new AutoMapping()); }).CreateMapper());

        services.AddScoped<IQuestionRepository, QuestionRepository>();
        services.AddScoped<ITestRepository, TestRepository>();
        services.AddScoped<ITestResultRepository, TestResultRepository>();
        services.AddScoped<IQuizesService, QuizesService>();
        services.AddScoped<ICandidatesService, CandidatesService>();
        services
            .AddControllers(options => options.Filters.Add<HttpResponseExceptionFilter>())
            .AddNewtonsoftJson(c =>
            {
                c.SerializerSettings.Converters.Add(new StringEnumConverter
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                });
            });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Quiz demo API", Version = "v1" });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
            options.UseInlineDefinitionsForEnums();
            options.EnableAnnotations();
        });
        services.AddSwaggerGenNewtonsoftSupport();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseRouting();
        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}