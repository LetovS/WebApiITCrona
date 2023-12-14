using Microsoft.EntityFrameworkCore;
using WebApiITCrona.Context;
using WebApiITCrona.Context.Abstract.Context;
using WebApiITCrona.Context.Entity;
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
}