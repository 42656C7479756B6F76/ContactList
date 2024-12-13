namespace ContactList.Dal.Models.Person;

public record PersonGetContactsModel
{
    public required long PersonId { get; init; }
}