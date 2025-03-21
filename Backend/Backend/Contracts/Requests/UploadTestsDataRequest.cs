using Backend.Contracts.Dtos;

namespace Backend.Contracts.Requests;

public record UploadTestsDataRequest(List<TestDataDto> TestsData);