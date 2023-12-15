using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using WebApiITCrona.Infrastructure.Context;

namespace WebApiITCrona;

/// <summary>
/// Менеджер миграций
/// </summary>
public static class DatabaseMigrationManager
{
    /// <summary>
    /// Миграция схемы БД
    /// </summary>
    /// <returns></returns>
    public static async Task MigrateSchema()
    {
        Console.WriteLine("Applying database schema migration...");

        await Migrate<CallStorageContext, CallStorageContextFactory>().ConfigureAwait(false);

        Console.WriteLine("Done");
    }

    private static async Task Migrate<TDbContext, TDbContextFactory>()
        where TDbContext : DbContext
        where TDbContextFactory : IDesignTimeDbContextFactory<TDbContext>, new()
    {
        var dbContextFactory = new TDbContextFactory();
        await using var dbContext = dbContextFactory.CreateDbContext(Array.Empty<string>());

        await dbContext.Database.MigrateAsync().ConfigureAwait(false);
    }
}
