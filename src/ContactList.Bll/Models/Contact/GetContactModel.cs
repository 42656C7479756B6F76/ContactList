namespace ContactList.Bll.Models.Contact;

public record GetContactModel
{
    public long Id { get; init; }

    public required string Name { get; init; }

    public required string PhoneNumber { get; init; }

    public required DateTimeOffset CreatedAt { get; init; }
}