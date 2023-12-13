using WebApiITCrona.Repositories.Abstract;

namespace WebApiITCrona.Repositories;

/// <summary>
/// Базовый репозиторий для чтения
/// </summary>
public abstract class ReadRepositoryBase : IReadRepository
{
    /// <summary>
    /// ctor.
    /// </summary>
    protected ReadRepositoryBase()
    {
        
    }
}