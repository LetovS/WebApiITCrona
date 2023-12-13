using Microsoft.AspNetCore.Mvc;
using WebApiITCrona.Services;

namespace WebApiITCrona.Controllers
{
    /// <summary>
    /// Контроллер геолокации
    /// </summary>
    [ApiController]
    [Route("api/v1/")]
    public class GeoController : ControllerBase
    {
        private readonly IService _geoService;
        private readonly ILogger<GeoController> _logger;

        /// <summary>
        /// ctor.
        /// </summary>
        public GeoController(ILogger<GeoController> logger, IService geoService)
        {
            _logger = logger;
            _geoService = geoService;
        }

        /// <summary>
        /// Получить ответ 
        /// </summary>
        [HttpGet(Name = "Get")]
        public async Task<ActionResult<string>> Get()
        {
            return await Task.FromResult("Test");
        }

        /// <summary>
        /// Получить ответ 1
        /// </summary>
        [HttpGet("from-body",Name = "GetFromBody")]
        public async Task<ActionResult<string>> GetFromBody([FromBody] string url)
        {
            return await Task.FromResult("Test");
        }
        
        /// <summary>
        /// Получить ответ
        /// </summary>
        [HttpGet("from-query",Name = "GetFromQuery")]
        public async Task<ActionResult<string>> GetFromQuery([FromQuery] string url)
        {
            return await Task.FromResult("Test");
        }
    }
}
