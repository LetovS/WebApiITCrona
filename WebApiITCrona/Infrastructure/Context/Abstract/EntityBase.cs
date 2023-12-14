using WebApiITCrona.Infrastructure.Context.Abstract.Entity;

namespace WebApiITCrona.Infrastructure.Context.Abstract;

/// <summary>
/// Базовая сущность
/// </summary>
public abstract class EntityBase : IDbEntity
{
    /// <inheritdoc/>
    public Guid Id { get; set; }

    /// <summary>
    /// ctor.
    /// </summary>
    protected EntityBase(Guid id)
    {
        Id = id;
    }
}