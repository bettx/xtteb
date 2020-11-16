using System.Threading;
using System.Threading.Tasks;
using MediatR;
using xbetter.Services.Generator.Macs._Base;
using xbetter.Services.Templater.Model;

namespace xbetter.Services.Generator.Macs.Host
{
    public class MacHostQuery : MacBaseQuery
    {
        public MacHostQuery(Landing landing) : base(landing)
        {
        }
    }

    public class MacHostHandler : IRequestHandler<MacHostQuery, string>
    {
        public async Task<string> Handle(MacHostQuery request, CancellationToken cancellationToken)
            => await Task.Factory.StartNew(() =>
            {
                var template = request.Landing.Template;

                template = template.Replace("[host]", request.Landing.Host);

                return template;

            }, cancellationToken);
    }
}
