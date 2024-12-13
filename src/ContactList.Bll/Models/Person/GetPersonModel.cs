namespace ContactList.Bll.Models.Person;

public record GetPersonModel
{
    public required long Id { get; init; }

    public required string FirstName { get; init; }

    public required string LastName { get; init; }
}