namespace ContactList.Bll.Models.Contact;

public record AddContactModel
{
    public required string Name { get; init; }

    public required string PhoneNumber { get; init; }

    public required long PersonId { get; init; }
}