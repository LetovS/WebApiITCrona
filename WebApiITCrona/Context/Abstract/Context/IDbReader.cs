namespace WebApiITCrona.Context.Abstract.Context;

public interface IDbReader
{
    IQueryable<TEntity> Read<TEntity>() where TEntity : class, IDbEntity;
}
