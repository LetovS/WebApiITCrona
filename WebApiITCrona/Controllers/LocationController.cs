using Microsoft.AspNetCore.Mvc;
using WebApiITCrona.Infrastructure.Models;
using WebApiITCrona.Services;

namespace WebApiITCrona.Controllers
{
    /// <summary>
    /// Контроллер геолокации
    /// </summary>
    [ApiController]
    [Route("api/v1/")]
    public class LocationController : ControllerBase
    {
        private readonly IService _geoService;

        /// <summary>
        /// ctor.
        /// </summary>
        public LocationController(IService geoService)
        {
            _geoService = geoService;
        }

        /// <summary>
        /// Получить данные об IP
        /// </summary>
        [HttpGet(Name = "GetInfoAboutIp")]
        [ProducesResponseType(typeof(IpInfoResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLocation([FromQuery] IpRequest ipRequest)
        {
            var response = await _geoService.GetInfoAboutIp(ipRequest);
            
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}
