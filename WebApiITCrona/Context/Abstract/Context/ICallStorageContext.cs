using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebApiITCrona.Context.Entity;

namespace WebApiITCrona.Context.Abstract.Context;

public interface ICallStorageContext
{
    DbSet<CallEntity> Calls { get; }
    
    DatabaseFacade Database { get; }
}
