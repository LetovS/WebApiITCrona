using WebApiITCrona.Repositories.Abstract;

namespace WebApiITCrona.Repositories;

/// <summary>
/// Базовый репозиторий для записи
/// </summary>
public abstract class WriteRepositoryBase : IWriteRepository
{
    /// <summary>
    /// ctor.
    /// </summary>
    protected WriteRepositoryBase()
    {
        
    }
}