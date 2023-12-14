namespace WebApiITCrona.Infrastructure.Models;

/// <summary>
/// Ответ для запроса к ресурсу />
/// </summary>
public class IpInfoResponse
{
    /// <summary>
    /// IP адрес
    /// </summary>
    public string? Ip { get; set; }

    /// <summary>
    /// Город
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Регион
    /// </summary>
    public string? Region { get; set; }

    /// <summary>
    /// Страна
    /// </summary>
    public string? Country { get; set; }

    /// <summary>
    /// Координаты
    /// </summary>
    public string? Loc { get; set; }

    /// <summary>
    /// Организация
    /// </summary>
    public string? Org { get; set; }

    /// <summary>
    /// Почтовый индекс
    /// </summary>
    public string? Postal { get; set; }

    /// <summary>
    /// Часовой пояс
    /// </summary>
    public string? Timezone { get; set; }

    /// <summary>
    /// URL на readme
    /// </summary>
    public string? Readme { get; set; }
}
