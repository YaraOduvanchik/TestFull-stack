using Backend.Contracts.Dtos;

namespace Backend.Contracts.Responses;

public record GetClientsWithContactsResponse(IReadOnlyCollection<ClientWithContactDto> Clients);