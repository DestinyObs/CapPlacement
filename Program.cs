using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using CapPlacement.Context;
using CapPlacement.Context;
using CapPlacement.Interfaces.Services;
using CapPlacement.Implementations.Services;
using CapPlacement.Interfaces.Repositories;
using TaskProjectWebAPI.Interfaces.Repositories;
using CapPlacement.Implementations.Repositories;

namespace CapPlacement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Load configuration from appsettings.json
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            builder.Services.AddDbContext<ApplicationContext>(options =>
                options.UseCosmos(
                    builder.Configuration["CosmosDBConnectionString"],
                    databaseName: builder.Configuration["CosmosDBDatabaseName"]));

            builder.Services.AddControllers();
            builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
            builder.Services.AddScoped<IProgramRepository, ProgramRepository>();
            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
            builder.Services.AddScoped<IStageRepository, StageRepository>();
            builder.Services.AddScoped<IApplicationTemplateService, ApplicationTemplateService>();
            builder.Services.AddScoped<IPreviewService, PreviewService>();
            builder.Services.AddScoped<IProgramDetailsService, ProgramDetailsService>();
            builder.Services.AddScoped<IWorkflowService, WorkflowService>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
