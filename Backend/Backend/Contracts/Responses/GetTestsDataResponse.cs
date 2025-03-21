namespace Backend.Contracts.Responses;

public record GetTestsDataResponse(IReadOnlyCollection<TestDataResponse> TestsData);