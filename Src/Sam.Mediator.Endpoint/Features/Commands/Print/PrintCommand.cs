
using FluentValidation;

namespace Sam.Mediator.Endpoint.Features.Commands.Print
{
    public class PrintCommand : IRequest<string>
    {
        public string Text { get; set; }
    }

    public class PrintCommandHandler : IRequestHandler<PrintCommand, string>
    {
        public Task<string> Handle(PrintCommand request, CancellationToken cancellationToken = default)
        {
            Console.WriteLine(request.Text);

            return Task.FromResult(request.Text);
        }
    }

    public class PrintCommandValidator : AbstractValidator<PrintCommand>
    {
        public PrintCommandValidator()
        {
            RuleFor(p => p.Text)
                .NotNull()
                .NotEmpty()
                .Length(7, 100);
        }
    }
}
