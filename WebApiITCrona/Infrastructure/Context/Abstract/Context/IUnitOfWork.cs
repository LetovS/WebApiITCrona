namespace WebApiITCrona.Infrastructure.Context.Abstract.Context;

/// <summary>
/// UnitOfWork
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Сохраняет изменения в БД
    /// </summary>
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}