using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using xbetter.Services.Templater.Model;
using xbetter.Settings;

namespace xbetter.Services.Templater
{
    public static class TemplateServiceExtentions
    {
        public static void AddTemplateService(this IServiceCollection services)
            => services.TryAddSingleton<ITemplaterService, TemplaterService>();
    }


    public interface ITemplaterService
    {
        Task<Landing> GetLanding(string name, bool simple = false);
    }


    public class TemplaterService : ITemplaterService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _httpContext;
        private readonly Doorsettings _doorsettings;

        public TemplaterService(IWebHostEnvironment env, IHttpContextAccessor httpContext, Doorsettings doorsettings)
        {
            _env = env;
            _httpContext = httpContext;
            _doorsettings = doorsettings;
        }

        public async Task<Landing> GetLanding(string name, bool simple = false)
        {
            if (simple)
            {
                return new Landing
                {
                    Template = await System.IO.File.ReadAllTextAsync($"{_env.WebRootPath}/templates/{name}")
                };
            }


            var landing = new Landing
            {
                Template = await System.IO.File.ReadAllTextAsync($"{_env.WebRootPath}/templates/{name}"),
                Host = _httpContext.HttpContext.Request.Host.Value,
                HostName = _httpContext.HttpContext.Request.Host.Host,
                RedirectLink = _doorsettings.redirect,
                Header = new Header
                {
                    Title = _doorsettings.title,
                    Description = _doorsettings.description
                },
                Body = new Body
                {
                    SiteName = _doorsettings.site_name,
                    H1 = _doorsettings.h1
                },
                KeyRandom = new KeyRandom(System.IO.File.ReadAllLines($"{_env.WebRootPath}/data/key/key.random.txt"))
            };

            return landing;
        }
    }
}