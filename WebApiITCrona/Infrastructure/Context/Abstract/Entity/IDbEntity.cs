namespace WebApiITCrona.Infrastructure.Context.Abstract.Entity;

/// <summary>
/// Сущность БД
/// </summary>
public interface IDbEntity : IEntity
{
    /// <summary>
    /// ИД сущности в БД
    /// </summary>
    public Guid Id { get; set; }
}