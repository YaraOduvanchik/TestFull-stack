using Backend.Contracts.Dtos;

namespace Backend.Contracts.Responses;

public record GetClientsWithMoreThanTwoContactsResponse(IReadOnlyCollection<ClientDto> Clients);