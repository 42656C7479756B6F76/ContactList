namespace ContactList.Bll.Models.Person;

public record AddPersonModel
{
    public required string FirstName { get; init; }

    public required string LastName { get; init; }
}