using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace xbetter.Services.Cacher
{
    public static class CacherServiceExtentions
    {
        public static void AddCacherService(this IServiceCollection services)
            => services.TryAddSingleton<ICacherService, CacherService>();
    }


    public interface ICacherService
    {
        Task SetCache(string name, string content);
        Task<string> GetCache(string name);
    }


    public class CacherService : ICacherService
    {
        private readonly IWebHostEnvironment _env;

        public CacherService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task SetCache(string name, string content)
            => await File.WriteAllTextAsync($"{_env.WebRootPath}/cache/{name}", content);

        public async Task<string> GetCache(string name)
            => File.Exists($"{_env.WebRootPath}/cache/{name}") 
                ? await File.ReadAllTextAsync($"{_env.WebRootPath}/cache/{name}")
                : null;
    }
}