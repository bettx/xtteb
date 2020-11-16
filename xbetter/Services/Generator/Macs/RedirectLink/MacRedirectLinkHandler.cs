using System.Threading;
using System.Threading.Tasks;
using MediatR;
using xbetter.Services.Generator.Macs._Base;
using xbetter.Services.Templater.Model;

namespace xbetter.Services.Generator.Macs.RedirectLink
{
    public class MacRedirectLinkQuery : MacBaseQuery
    {
        public MacRedirectLinkQuery(Landing landing) : base(landing)
        {
        }
    }

    public class MacRedirectLinkHandler : IRequestHandler<MacRedirectLinkQuery, string>
    {
        public async Task<string> Handle(MacRedirectLinkQuery request, CancellationToken cancellationToken)
            => await Task.Factory.StartNew(() => request.Landing.Template.Replace("[redirect.link]", request.Landing.RedirectLink), cancellationToken);
    }
}
