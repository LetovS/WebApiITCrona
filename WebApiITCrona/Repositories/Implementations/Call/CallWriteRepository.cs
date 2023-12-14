using WebApiITCrona.Infrastructure.Context.Abstract.Context;
using WebApiITCrona.Infrastructure.Context.Entity;
using WebApiITCrona.Repositories.Abstract;

namespace WebApiITCrona.Repositories.Implementations.Call;

/// <summary>
/// Репозиторий записи
/// </summary>
public sealed class CallWriteRepository : IWriteRepository<CallEntity>
{
    private readonly IDbWriter writer;

    /// <summary>
    /// ctor.
    /// </summary>
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