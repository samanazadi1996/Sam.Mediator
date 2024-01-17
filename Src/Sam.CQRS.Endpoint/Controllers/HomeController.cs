using Microsoft.AspNetCore.Mvc;
using Sam.CQRS.Endpoint.Features.Commands.Print;
using Sam.CQRS.Framework;
using System.Threading.Tasks;

namespace Sam.CQRS.Endpoint.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ISender sender;

        public HomeController(ISender sender)
        {
            this.sender = sender;
        }

        [HttpPost("Print")]
        public async Task<string> Print(PrintCommand command)
            => await sender.Send(command);
    }
}
