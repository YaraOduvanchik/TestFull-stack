using Backend.Contracts.Requests;
using Backend.Contracts.Responses;
using Backend.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Data;

public class GetTestsDataHandler
{
    private readonly AppDbContext _context;

    public GetTestsDataHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetTestsDataResponse> Handle(
        GetTestsDataRequest request,
        CancellationToken cancellationToken)
    {
        var query = _context.DataItems.AsQueryable();

        if (request.Code.HasValue)
        {
            query = query.Where(d => d.Code == request.Code.Value);
        }

        if (!string.IsNullOrWhiteSpace(request.Value))
        {
            query = query.Where(d => d.Value.Contains(request.Value));
        }

        var data = await query
            .OrderBy(d => d.Code)
            .Select(d => new TestDataResponse(d.Id, d.Code, d.Value))
            .ToListAsync(cancellationToken: cancellationToken);

        return new GetTestsDataResponse(data);
    }
}