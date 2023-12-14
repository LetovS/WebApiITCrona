using WebApiITCrona.Context.Abstract.Context;
using WebApiITCrona.Context.Entity;
using WebApiITCrona.Repositories.Abstract;

namespace WebApiITCrona.Repositories.Implementations.Call;

/// <summary>
/// Репозиторий записи
/// </summary>
public sealed class CallWriteRepository : IWriteRepository<CallEntity>
{
    private readonly IDbWriter writer;

    public CallWriteRepository(IDbWriter writer)
    {
        this.writer = writer;
    }

    /// <inheritdoc/>
    public void Add(CallEntity entity)
    {
        writer.Add(entity);
    }
}