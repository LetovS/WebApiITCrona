using WebApiITCrona.Infrastructure.Context.Abstract.Entity;

namespace WebApiITCrona.Infrastructure.Context.Abstract.Context;

/// <summary>
/// Запись в БД
/// </summary>
public interface IDbWriter
{
    /// <summary>
    /// Добавление новой сущность в БД
    /// </summary>
    void Add<TEntity>(TEntity data) where TEntity : class, IDbEntity;

    /// <summary>
    /// Обновляет сущность в БД
    /// </summary>
    void Update<TEntity>(TEntity data) where TEntity : class, IDbEntity;

    /// <summary>
    /// Удаляет сущность из БД
    /// </summary>
    void Delete<TEntity>(TEntity data) where TEntity : class, IDbEntity;
}