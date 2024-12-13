namespace ContactList.Dal.Models.Contact;

public record ContactUpdateModel
{
    public long Id { get; init; }

    public required string Name { get; init; }

    public required string PhoneNumber { get; init; }

    public required long PersonId { get; init; }
}