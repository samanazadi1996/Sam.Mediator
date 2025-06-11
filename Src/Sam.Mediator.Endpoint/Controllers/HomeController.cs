using Microsoft.AspNetCore.Mvc;
using Sam.Mediator.Endpoint.Features.Commands.Print;

namespace Sam.Mediator.Endpoint.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController(IMediator mediator) : ControllerBase
{

    [HttpPost("Print")]
    public async Task<string> Print(PrintCommand command)
        => await mediator.Send<PrintCommand, string>(command);

    [HttpPost("Print2")]
    public async Task<string> Print2(PrintCommand command)
        => await mediator.Send(command);
}
