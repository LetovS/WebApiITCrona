using Microsoft.EntityFrameworkCore;
using WebApiITCrona.Context;

namespace WebApiITCrona.DI;

public static class ServiceCollectionsExtensions
{
    public static void AddCallStorageContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CallStorageContext>(options => options.UseSqlServer(connectionString: configuration.GetConnectionString("Default"),
            opt =>
            {
                opt.MigrationsHistoryTable("__EFMigrationsHistory");
                opt.MigrationsAssembly(typeof(CallStorageContext).Assembly.GetName().Name);
            }));
    }
}