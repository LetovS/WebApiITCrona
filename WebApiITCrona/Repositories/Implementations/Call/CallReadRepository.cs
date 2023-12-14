using Microsoft.EntityFrameworkCore;
using WebApiITCrona.Context.Abstract.Context;
using WebApiITCrona.Context.Abstract.Entity;
using WebApiITCrona.Context.Entity;
using WebApiITCrona.Repositories.Abstract;

namespace WebApiITCrona.Repositories.Implementations.Call;

/// <summary>
/// Репозиторий чтения
/// </summary>
public sealed class CallReadRepository : IReadRepository<CallEntity>
{
    private readonly IDbReader reader;

    /// <summary>
    /// ctor.
    /// </summary>
    public CallReadRepository(IDbReader reader)
    {
        this.reader = reader;
    }
    /// <inheritdoc/>
    public async Task<CallEntity?> GetEntityByIpAddress(string ipAddress, CancellationToken ct)
    {
        return await reader
            .Read<CallEntity>()
            .Where(x => x.IpAddress.Equals(ipAddress))
            .SingleOrDefaultAsync(ct);
    }
}