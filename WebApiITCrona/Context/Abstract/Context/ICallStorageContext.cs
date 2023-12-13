using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebApiITCrona.Context.Entity;

namespace WebApiITCrona.Context.Abstract.Context;

/// <summary>
/// Определяет 
/// </summary>
public interface ICallStorageContext
{
    /// <summary>
    /// Сущности
    /// </summary>
    DbSet<CallEntity> Calls { get; }
    
    /// <summary>
    /// Фасад базы данных
    /// </summary>
    DatabaseFacade Database { get; }
}
