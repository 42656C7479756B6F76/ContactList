using ContactList.Domain.ValueObjects.Person;

namespace ContactList.Domain;

public class PersonEntityV1
{
    private readonly Id _id;
    
    private readonly FirstName _firstName;
    
    private readonly LastName _lastName;

    public long Id
    {
        get => _id;
        init => _id = value;
    }

    public required string FirstName
    {
        get => _firstName;
        init => _firstName = value;
    }

    public required string LastName
    {
        get => _lastName;
        init => _lastName = value;
    }

    public required DateTimeOffset CreatedAt { get; init; }
}