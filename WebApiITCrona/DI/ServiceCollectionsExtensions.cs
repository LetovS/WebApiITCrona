using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WebApiITCrona.Infrastructure.Context;
using WebApiITCrona.Infrastructure.Context.Abstract.Context;
using WebApiITCrona.Infrastructure.Context.Entity;
using WebApiITCrona.Infrastructure.Options;
using WebApiITCrona.Repositories.Abstract;
using WebApiITCrona.Repositories.Implementations.Call;
using WebApiITCrona.Services;

namespace WebApiITCrona.DI;

/// <summary>
/// Расширение для <see cref="IServiceCollection"/>
/// </summary>
public static class ServiceCollectionsExtensions
{
    /// <summary>
    /// Добавляет контекст БД
    /// </summary>
    public static void AddCallStorageContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CallStorageContext>(options => options.UseSqlServer(connectionString: configuration.GetConnectionString("Default"),
            opt =>
            {
                opt.MigrationsHistoryTable("__EFMigrationsHistory");
                opt.MigrationsAssembly(typeof(CallStorageContext).Assembly.GetName().Name);
            }));


        services.AddScoped<ICallStorageContext>(serviceProvider => serviceProvider.GetRequiredService<CallStorageContext>());
        services.AddScoped<IDbReader>(serviceProvider => serviceProvider.GetRequiredService<CallStorageContext>());
        services.AddScoped<IDbWriter>(serviceProvider => serviceProvider.GetRequiredService<CallStorageContext>());
        services.AddScoped<IUnitOfWork>(serviceProvider => serviceProvider.GetRequiredService<CallStorageContext>());
    }

    /// <summary>
    /// Добавляет сервисы
    /// </summary>
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IService, GeoService>();
    }
    
    /// <summary>
    /// Добавляет репозитории
    /// </summary>
    /// <param name="services"></param>
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IReadRepository<CallEntity>, CallReadRepository>();
        services.AddScoped<IWriteRepository<CallEntity>, CallWriteRepository>();
    }

    /// <summary>
    /// Добавляет настройки для зависисомтей
    /// </summary>
    public static void AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CustomHttpClientOptions>(configuration.GetSection(nameof(CustomHttpClientOptions)));
    }

    /// <summary>
    /// Добавляет пользовательский HttpClient
    /// </summary>
    public static void AddCustomHttpClient(this IServiceCollection services, IOptions<CustomHttpClientOptions> httpClientOptions)
    {
        var options = httpClientOptions.Value;
        services.AddHttpClient(options.HttpClientName, baseUrl => baseUrl.BaseAddress = options.UriBase);
    }
}