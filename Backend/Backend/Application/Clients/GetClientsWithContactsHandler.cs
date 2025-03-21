using Backend.Contracts.Dtos;
using Backend.Contracts.Responses;
using Backend.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Clients;

public class GetClientsWithContactsHandler
{
    private readonly AppDbContext _context;

    public GetClientsWithContactsHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetClientsWithContactsResponse> Handle(CancellationToken cancellationToken)
    {
        var clientsWithContacts = await _context.Clients
            .GroupJoin(
                _context.ClientContacts,
                client => client.Id,
                contact => contact.ClientId,
                (client, contacts) => new
                {
                    ClientName = client.ClientName,
                    ContactCount = contacts.Count()
                }
            )
            .Select(x => new ClientWithContactDto(x.ClientName, x.ContactCount))
            .ToListAsync(cancellationToken);
        
        return new GetClientsWithContactsResponse(clientsWithContacts);
    }
}