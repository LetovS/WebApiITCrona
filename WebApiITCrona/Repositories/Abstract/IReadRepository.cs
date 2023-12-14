using WebApiITCrona.Infrastructure.Context.Abstract.Entity;

namespace WebApiITCrona.Repositories.Abstract;

/// <summary>
/// Интерфейс репозитория чтения
/// </summary>
public interface IReadRepository<TEntity> where TEntity : IDbEntity
{
    /// <summary>
    /// Проверяет существования сущности с таким IP address
    /// </summary>
    Task<TEntity?> GetEntityByIpAddress(string ipAddress, CancellationToken ct = default);
}