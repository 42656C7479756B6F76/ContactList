namespace ContactList.Dal.Models.Person;

public record PersonUpdateModel
{
    public required long Id { get; init; }

    public required string FirstName { get; init; }

    public required string LastName { get; init; }
}