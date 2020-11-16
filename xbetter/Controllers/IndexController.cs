using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using xbetter.Services.Cacher;
using xbetter.Services.Generator;
using xbetter.Services.Templater;

namespace xbetter.Controllers
{
    [ApiController]
    [Route("/")]
    public class IndexController : ControllerBase
    {
        private readonly ICacherService _cacherService;
        private readonly ITemplaterService _templaterService;
        private readonly IGeneratorService _generatorService;

        public IndexController(
            ICacherService cacherService,
            ITemplaterService templaterService,
            IGeneratorService generatorService
        )
        {
            _cacherService = cacherService;
            _templaterService = templaterService;
            _generatorService = generatorService;
        }

        [HttpGet]
        [Produces("text/html")]
        public async Task<IActionResult> Get()
        {
            var template = await _cacherService.GetCache("index");

            if (template == null)
            {
                var landing = await _templaterService.GetLanding("index.html");

                template = await _generatorService.Generate(landing);

                //await _cacherService.SetCache("index", landing.Template);
            }
            
            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int) HttpStatusCode.OK,
                Content = template
            };
        }
    }
}