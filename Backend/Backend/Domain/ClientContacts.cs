namespace Backend.Domain;

public class ClientContacts
{
    public long Id { get; set; }
    public long ClientId { get; set; }
    public string ContactType { get; set; } = null!;
    public string ContactValue { get; set; } = null!;
}