using MediatR;
using xbetter.Services.Templater.Model;

namespace xbetter.Services.Generator.Macs._Base
{
    public class MacBaseQuery : IRequest<string>
    {
        protected MacBaseQuery(Landing landing) 
            => Landing = landing;

        public Landing Landing { get; }
    }
}
