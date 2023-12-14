using WebApiITCrona.Infrastructure.Context.Abstract;

namespace WebApiITCrona.Infrastructure.Context.Entity;

/// <summary>
/// Сущность вызова
/// </summary>
public sealed class CallEntity : EntityBase
{
    /// <summary>
    /// ctor.
    /// </summary>
    public CallEntity(Guid id, string ipAddress) : base(id)
    {
        IpAddress = ipAddress;
    }

    /// <summary>
    /// IP адресс
    /// </summary>
    public string IpAddress { get; set; }
}