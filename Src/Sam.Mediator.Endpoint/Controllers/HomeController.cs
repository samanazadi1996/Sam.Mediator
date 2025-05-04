using Microsoft.AspNetCore.Mvc;
using Sam.Mediator.Endpoint.Features.Commands.Print;

namespace Sam.Mediator.Endpoint.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController(IMediator mediator) : ControllerBase
{

    [HttpPost("Print")]
    public async Task<string> Print(PrintCommand command)
        => await mediator.SendAsync<PrintCommand, string>(command);
}
