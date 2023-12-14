namespace WebApiITCrona.Infrastructure.Context.Abstract.Context;

/// <summary>
/// Ридер базы данных
/// </summary>
public interface IDbReader
{
    /// <summary>
    /// Выполняет чтение БД <see cref="EntityBase"/>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <returns></returns>
    IQueryable<TEntity> Read<TEntity>() where TEntity : EntityBase;
}
