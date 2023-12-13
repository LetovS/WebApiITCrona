namespace WebApiITCrona.Context.Abstract;

public interface IDbEntity : IEntity
{
    public Guid Id { get; set; }
}