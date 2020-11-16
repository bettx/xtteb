using System.Threading;
using System.Threading.Tasks;
using MediatR;
using xbetter.Services.Generator.Macs._Base;
using xbetter.Services.Templater.Model;

namespace xbetter.Services.Generator.Macs.Title
{
    public class MacTitleQuery : MacBaseQuery
    {
        public MacTitleQuery(Landing landing) : base(landing)
        {
        }
    }

    public class MacTitleHandler : IRequestHandler<MacTitleQuery, string>
    {
        public async Task<string> Handle(MacTitleQuery request, CancellationToken cancellationToken)
            => await Task.Factory.StartNew(() => request.Landing.Template.Replace("[title]", request.Landing.Header.Title), cancellationToken);
    }
}
