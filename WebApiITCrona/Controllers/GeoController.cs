using Microsoft.AspNetCore.Mvc;

namespace WebApiITCrona.Controllers
{
    [ApiController]
    [Route("api/v1/[action]")]
    public class GeoController : ControllerBase
    {        
        private readonly ILogger<GeoController> _logger;
        private readonly IHttpClientFactory httpClient;

        public GeoController(ILogger<GeoController> logger, IHttpClientFactory httpClient)
        {
            _logger = logger;
            this.httpClient = httpClient;
        }

        [HttpGet(Name = "GetTest1")]
        public async Task<ActionResult<string>> Get()
        {
            return await Task.FromResult("Test");
        }

        [HttpGet(Name = "GetTest2")]
        public async Task<ActionResult<string>> GetFromBody([FromBody] string url)
        {
            return await Task.FromResult("Test");
        }

        [HttpGet(Name = "GetTest3")]
        public async Task<ActionResult<string>> GetFromquery([FromQuery] string url)
        {
            return await Task.FromResult("Test");
        }
    }
}
