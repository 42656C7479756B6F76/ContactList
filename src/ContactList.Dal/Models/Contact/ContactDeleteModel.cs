namespace ContactList.Dal.Models.Contact;

public record ContactDeleteModel
{
    public required long ContactId { get; init; }
}