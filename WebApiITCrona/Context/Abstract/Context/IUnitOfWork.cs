namespace WebApiITCrona.Context.Abstract.Context;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken ct = default);
}