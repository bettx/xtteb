using System.Threading;
using System.Threading.Tasks;
using MediatR;
using xbetter.Services.Generator.Macs._Base;
using xbetter.Services.Templater.Model;

namespace xbetter.Services.Generator.Macs.SiteName
{
    public class MacSiteNameQuery : MacBaseQuery
    {
        public MacSiteNameQuery(Landing landing) : base(landing)
        {
        }
    }

    public class MacSiteNameHandler : IRequestHandler<MacSiteNameQuery, string>
    {
        public async Task<string> Handle(MacSiteNameQuery request, CancellationToken cancellationToken)
            => await Task.Factory.StartNew(() => request.Landing.Template.Replace("[site.name]", request.Landing.Body.SiteName), cancellationToken);
    }
}
