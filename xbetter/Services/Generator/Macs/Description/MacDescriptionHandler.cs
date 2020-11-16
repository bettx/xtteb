using System.Threading;
using System.Threading.Tasks;
using MediatR;
using xbetter.Services.Generator.Macs._Base;
using xbetter.Services.Templater.Model;

namespace xbetter.Services.Generator.Macs.Description
{
    public class MacDescriptionQuery : MacBaseQuery
    {
        public MacDescriptionQuery(Landing landing) : base(landing)
        {
        }
    }

    public class MacDescriptionHandler : IRequestHandler<MacDescriptionQuery, string>
    {
        public async Task<string> Handle(MacDescriptionQuery request, CancellationToken cancellationToken)
            => await Task.Factory.StartNew(() => request.Landing.Template.Replace("[description]", request.Landing.Header.Description), cancellationToken);
    }
}
