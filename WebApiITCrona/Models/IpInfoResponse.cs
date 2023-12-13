namespace WebApiITCrona.Models;

/// <summary>
/// Ответ для запроса к ресурсу />
/// </summary>
public class IpInfoResponse
{
    public string Ip { get; set; }
    public string City { get; set; }    
    public string Region { get; set; }
    public string Country { get; set; }
    public string Loc { get; set; }
    public string Org { get; set; }
    public string Postal { get; set; }
    public string Timezone { get; set; }
    /// <summary>
    /// URL на readme
    /// </summary>
    public string Readme { get; set; }
}
