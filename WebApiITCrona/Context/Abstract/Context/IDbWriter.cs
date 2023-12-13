namespace WebApiITCrona.Context.Abstract.Context;

public interface IDbWriter
{
    void Add<TEntity>(TEntity data) where TEntity : class, IDbEntity;
    void Update<TEntity>(TEntity data) where TEntity : class, IDbEntity;
    void Delete<TEntity>(TEntity data) where TEntity : class, IDbEntity;
}