using WebApiITCrona.Context.Abstract;

namespace WebApiITCrona.Context.Entity;

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