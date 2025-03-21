using Backend.Application.DateInterval;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DateIntervalController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(
        [FromServices] GetDateIntervalsHandler handler,
        CancellationToken cancellationToken)
    {
        var result = await handler.Handle(cancellationToken);

        return Ok(result);
    }
}