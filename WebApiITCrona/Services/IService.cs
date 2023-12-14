using WebApiITCrona.Infrastructure.Models;

namespace WebApiITCrona.Services;

/// <summary>
/// Интерфейс определяющий функционал сервисов геолокации
/// </summary>
public interface IService
{
    /// <summary>
    /// Получить информацию по IP
    /// </summary>
    Task<IpInfoResponse> GetInfoAboutIp(IpRequest ipRequest);
}
