using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using xbetter.Services.Templater;

namespace xbetter.Controllers
{
    [ApiController]
    [Route("/robots.txt")]
    public class RobotsController : ControllerBase
    {
        private readonly ITemplaterService _templaterService;
        
        public RobotsController(ITemplaterService templaterService)
        {
            _templaterService = templaterService;
        }

        [HttpGet]
        [Produces("text/plain")]
        public async Task<IActionResult> GetRobotsTxt()
        {
            var landing = await _templaterService.GetLanding("robots.txt", true);

            return new ContentResult {
                ContentType = "text/plain",
                StatusCode = (int) HttpStatusCode.OK,
                Content = landing.Template
            };
        }
    }
}
