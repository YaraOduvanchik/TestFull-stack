using Backend.Contracts.Dtos;

namespace Backend.Contracts.Responses;

public record GetDateIntervalsResponse(IReadOnlyCollection<DateIntervalDto> Intervals);