using System.Threading;
using System.Threading.Tasks;
using MediatR;
using xbetter.Services.Generator.Macs._Base;
using xbetter.Services.Templater.Model;

namespace xbetter.Services.Generator.Macs.Metrika
{
    public class MacMetrikaQuery : MacBaseQuery
    {
        public MacMetrikaQuery(Landing landing) : base(landing)
        {
        }
    }

    public class MacTitleHandler : IRequestHandler<MacMetrikaQuery, string>
    {
        public async Task<string> Handle(MacMetrikaQuery request, CancellationToken cancellationToken)
            => await Task.Factory.StartNew(() => request.Landing.Template.Replace("[metrika.id]", request.Landing.MetricaId), cancellationToken);
    }
}
