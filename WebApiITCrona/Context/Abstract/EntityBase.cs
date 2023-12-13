namespace WebApiITCrona.Context.Abstract;

public abstract class EntityBase : IDbEntity
{
    public Guid Id { get; set; }

    protected EntityBase(Guid id)
    {
        Id = id;
    }
}