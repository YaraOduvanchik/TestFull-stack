namespace Backend.Domain;

public class DataItem
{
    public Guid Id { get; set; }
    public int Code { get; set; }
    public required string Value { get; set; }
}