using Backend.Application.Data;
using Backend.Contracts.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class DataController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Upload(
        [FromBody] UploadTestsDataRequest request,
        [FromServices] UploadTestsDataHandler handler,
        CancellationToken cancellationToken)
    {
        var result = await handler.Handle(request, cancellationToken);
        if (!string.IsNullOrEmpty(result))
        {
            return BadRequest(result);
        }

        return Ok();
    }
    
    [HttpGet]
    public async Task<IActionResult> Get(
        [FromQuery] GetTestsDataRequest request,
        [FromServices] GetTestsDataHandler handler,
        CancellationToken cancellationToken)
    {
        var result = await handler.Handle(request, cancellationToken);
        return Ok(result);
    }
}