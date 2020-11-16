using Microsoft.AspNetCore.Mvc;
using xbetter.Settings;

namespace xbetter.Controllers
{
    [Route("reg")]
    public class RedirectController : Controller
    {
        private readonly Doorsettings _doorsettings;

        public RedirectController(Doorsettings doorsettings)
        {
            _doorsettings = doorsettings;
        }

        [HttpGet]
        public IActionResult Get() 
            => Redirect(_doorsettings.redirect);
    }
}
