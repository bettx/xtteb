using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using xbetter.Services.ApiLogger;
using xbetter.Services.Cacher;
using xbetter.Services.Generator;
using xbetter.Services.Templater;
using xbetter.Settings;

namespace xbetter
{
    public class Startup
    {
        private readonly Doorsettings _doorsettings;

        public Startup(IConfiguration configuration)
        {
            _doorsettings = configuration.GetSection("Door").Get<Doorsettings>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMediatR(typeof(Startup));
            services.AddHttpContextAccessor();
            services.AddSingleton(_doorsettings);
            services.AddCacherService();
            services.AddTemplateService();
            services.AddGeneratorService();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseApiLoggerMiddleware();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}