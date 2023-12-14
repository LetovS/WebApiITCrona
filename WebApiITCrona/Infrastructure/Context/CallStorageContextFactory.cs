using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebApiITCrona.Infrastructure.Context;

/// <summary>
/// Фабрика для генерации миграций
/// </summary>
public class CallStorageContextFactory : IDesignTimeDbContextFactory<CallStorageContext>
{
    /// <summary>
    /// ctor.
    /// </summary>
    public CallStorageContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<CallStorageContext>();

        optionBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ItCronaTest;");

        return new CallStorageContext(optionBuilder.Options);
    }
}