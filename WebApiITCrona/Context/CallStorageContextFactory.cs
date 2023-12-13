using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebApiITCrona.Context;

public class CallStorageContextFactory : IDesignTimeDbContextFactory<CallStorageContext>
{
    public CallStorageContext CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<CallStorageContext>();
        
        optionBuilder.UseSqlServer("");
        
        return new CallStorageContext(optionBuilder.Options);
    }
}