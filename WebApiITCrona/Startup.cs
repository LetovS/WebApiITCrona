using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using WebApiITCrona.DI;
using WebApiITCrona.Infrastructure.Options;
using WebApiITCrona.Infrastructure.Validators;

namespace WebApiITCrona;

/// <summary>
/// Настройка веб хоста
/// </summary>
public class Startup
{
    /// <summary>
    /// Конфигурации
    /// </summary>
    public IConfiguration Configuration { get; }

    /// <summary>
    /// ctor.
    /// </summary>
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    /// <summary>
    /// Конфигурация сервисов
    /// </summary>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services.AddFluentValidationAutoValidation(cfg =>
        {
            cfg.DisableDataAnnotationsValidation = false;
        });
        services.AddValidatorsFromAssemblyContaining<IpRequestValidator>();

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Web API",
                Version = "v1"
            });
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        services.AddCustomOptions(Configuration);

        var options = services.BuildServiceProvider().GetRequiredService<IOptions<CustomHttpClientOptions>>();
        services.AddCustomHttpClient(options);

        services.AddCallStorageContext(Configuration);

        services.AddServices();

        services.AddRepositories();
    }

    /// <summary>
    /// Конфигурация middlewear
    /// </summary>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        //app.UseAuthorization();

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}