using System.Threading;
using System.Threading.Tasks;
using MediatR;
using xbetter.Services.Generator.Macs._Base;
using xbetter.Services.Templater.Model;

namespace xbetter.Services.Generator.Macs.HostName
{
    public class MacHostNameQuery : MacBaseQuery
    {
        public MacHostNameQuery(Landing landing) : base(landing)
        {
        }
    }

    public class MacHostNameHandler : IRequestHandler<MacHostNameQuery, string>
    {
        public async Task<string> Handle(MacHostNameQuery request, CancellationToken cancellationToken)
            => await Task.Factory.StartNew(() =>
            {
                var template = request.Landing.Template;

                template = template.Replace("[host.name]", request.Landing.HostName);

                return template;

            }, cancellationToken);
    }
}
