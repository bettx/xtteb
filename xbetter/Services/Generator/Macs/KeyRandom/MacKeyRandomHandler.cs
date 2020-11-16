using System.Threading;
using System.Threading.Tasks;
using MediatR;
using xbetter.Helpers;
using xbetter.Services.Generator.Macs._Base;
using xbetter.Services.Templater.Model;

namespace xbetter.Services.Generator.Macs.KeyRandom
{
    public class MacKeyRandomQuery : MacBaseQuery
    {
        public MacKeyRandomQuery(Landing landing) : base(landing)
        {
        }
    }

    public class MacKeyRandomHandler : IRequestHandler<MacKeyRandomQuery, string>
    {
        public async Task<string> Handle(MacKeyRandomQuery request, CancellationToken cancellationToken)
        {
            return await Task.Factory.StartNew(() =>
            {
                var i = 0;
                while (request.Landing.Template.Contains("[key.random]"))
                {
                    request.Landing.Template = request.Landing.Template.FReplace("[key.random]", request.Landing.KeyRandom.Keys[i]);

                    i++;

                    if (i >= request.Landing.KeyRandom.Keys.Count)
                    {
                        i = 0;
                    }
                }

                return request.Landing.Template;
            }, cancellationToken);
        }
    }
}
