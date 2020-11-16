using System.Threading;
using System.Threading.Tasks;
using MediatR;
using xbetter.Services.Generator.Macs._Base;
using xbetter.Services.Templater.Model;

namespace xbetter.Services.Generator.Macs.H1
{
    public class MacH1Query : MacBaseQuery
    {
        public MacH1Query(Landing landing) : base(landing)
        {
        }
    }

    public class MacH1Handler : IRequestHandler<MacH1Query, string>
    {
        public async Task<string> Handle(MacH1Query request, CancellationToken cancellationToken)
            => await Task.Factory.StartNew(() => request.Landing.Template.Replace("[h1]", request.Landing.Body.H1), cancellationToken);
    }
}
