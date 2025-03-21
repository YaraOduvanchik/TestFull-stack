using Backend.Application.Clients;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientsController : ControllerBase
{
    [HttpGet("with-contacts")]
    public async Task<IActionResult> GetClientsWithContacts(
        [FromServices] GetClientsWithContactsHandler handler,
        CancellationToken cancellationToken)
    {
        var result = await handler.Handle(cancellationToken);

        return Ok(result);
    }
    
    [HttpGet("with-more-than-two-contacts")]
    public async Task<IActionResult> GetClientsWithMoreThanTwoContacts(
        [FromServices] GetClientsWithMoreThanTwoContactsHandler handler,
        CancellationToken cancellationToken)
    {
        var result = await handler.Handle(cancellationToken);

        return Ok(result);
    }
}