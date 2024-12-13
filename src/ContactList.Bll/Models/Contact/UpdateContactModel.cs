namespace ContactList.Bll.Models.Contact;

public record UpdateContactModel
{
    public required long Id { get; init; }

    public required string Name { get; init; }

    public required string PhoneNumber { get; init; }

    public required long PersonId { get; init; }
}