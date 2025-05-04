
namespace Sam.Mediator.Endpoint.Features.Commands.Print
{
    public class PrintCommand : IRequest<string>
    {
        public string Text { get; set; }
    }

    public class PrintCommandHandler : IRequestHandler<PrintCommand, string>
    {
        public Task<string> HandleAsync(PrintCommand request, CancellationToken cancellationToken = default)
        {
            Console.WriteLine(request.Text);

            return Task.FromResult(request.Text);
        }
    }

}
