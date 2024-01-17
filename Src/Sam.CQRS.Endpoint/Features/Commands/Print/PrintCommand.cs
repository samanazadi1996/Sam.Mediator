using Sam.CQRS.Framework;
using System;
using System.Threading.Tasks;

namespace Sam.CQRS.Endpoint.Features.Commands.Print
{
    public class PrintCommand : IRequest<string>
    {
        public string str { get; set; }
    }
    public class PrintCommandHandler : IRequestHandler<PrintCommand, string>
    {
        public Task<string> Handler(PrintCommand request)
        {
            Console.WriteLine(request.str);

            return Task.FromResult(request.str);
        }
    }
}
