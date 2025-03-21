using Backend.Contracts.Dtos;
using Backend.Contracts.Responses;
using Backend.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Clients;

public class GetClientsWithMoreThanTwoContactsHandler
{
    private readonly AppDbContext _context;

    public GetClientsWithMoreThanTwoContactsHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetClientsWithMoreThanTwoContactsResponse> Handle(CancellationToken cancellationToken)
    {
        var clients = await _context.Clients
            .Where(client => _context.ClientContacts
                .Count(contact => contact.ClientId == client.Id) > 2) 
            .Select(client => new ClientDto(
                client.Id,
                client.ClientName
            ))
            .ToListAsync(cancellationToken);

        return new GetClientsWithMoreThanTwoContactsResponse(clients);
    }
}
