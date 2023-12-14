namespace WebApiITCrona.Infrastructure.Options;

/// <summary>
/// Настройки для httpclient
/// </summary>
public sealed class CustomHttpClientOptions
{
    /// <summary>
    /// Название http client
    /// </summary>
    public string HttpClientName { get; set; }

    /// <summary>
    /// Базовый адрес
    /// </summary>
    public Uri UriBase { get; set; }
}