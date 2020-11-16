using System.Threading;
using System.Threading.Tasks;
using MediatR;
using xbetter.Services.Generator.Macs._Base;
using xbetter.Services.Templater.Model;

namespace xbetter.Services.Generator.Macs.Paragraph
{
    public class MacParagraphQuery : MacBaseQuery
    {
        public MacParagraphQuery(Landing landing) : base(landing)
        {
        }
    }

    public class MacParagraphHandler : IRequestHandler<MacParagraphQuery, string>
    {
        public async Task<string> Handle(MacParagraphQuery request, CancellationToken cancellationToken)
            => await Task.Factory.StartNew(() =>
            {
                var template = request.Landing.Template;

                return template;

            }, cancellationToken);
    }
}