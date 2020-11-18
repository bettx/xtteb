using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using xbetter.Services.Generator.Macs.Description;
using xbetter.Services.Generator.Macs.H1;
using xbetter.Services.Generator.Macs.Host;
using xbetter.Services.Generator.Macs.HostName;
using xbetter.Services.Generator.Macs.KeyRandom;
using xbetter.Services.Generator.Macs.Metrika;
using xbetter.Services.Generator.Macs.RedirectLink;
using xbetter.Services.Generator.Macs.SiteName;
using xbetter.Services.Generator.Macs.Title;
using xbetter.Services.Templater.Model;

namespace xbetter.Services.Generator
{
    public static class GeneratorServiceExtentions
    {
        public static void AddGeneratorService(this IServiceCollection services)
            => services.TryAddSingleton<IGeneratorService, GeneratorService>();
    }


    public interface IGeneratorService
    {
        Task<string> Generate(Landing landing);
    }


    public class GeneratorService : IGeneratorService
    {
        private readonly ILogger<GeneratorService> _logger;
        private readonly IMediator _mediator;

        public GeneratorService(ILogger<GeneratorService> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<string> Generate(Landing landing)
        {
            _logger.LogInformation("Generating template");

            landing.Template = await _mediator.Send(new MacTitleQuery(landing));
            landing.Template = await _mediator.Send(new MacDescriptionQuery(landing));
            landing.Template = await _mediator.Send(new MacSiteNameQuery(landing));
            landing.Template = await _mediator.Send(new MacH1Query(landing));
            landing.Template = await _mediator.Send(new MacHostQuery(landing));
            landing.Template = await _mediator.Send(new MacHostNameQuery(landing));
            landing.Template = await _mediator.Send(new MacRedirectLinkQuery(landing));
            landing.Template = await _mediator.Send(new MacKeyRandomQuery(landing));
            landing.Template = await _mediator.Send(new MacMetrikaQuery(landing));

            return landing.Template;
        }
    }
}