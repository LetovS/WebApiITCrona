using WebApiITCrona.Infrastructure.Context.Abstract.Entity;

namespace WebApiITCrona.Repositories.Abstract;

/// <summary>
/// Интерфейс репозитория записи
/// </summary>
public interface IWriteRepository<TEntity> where TEntity : IDbEntity
{
    /// <summary>
    /// Добавить Ip адрес в БД
    /// </summary>
    void Add(TEntity entity);
}