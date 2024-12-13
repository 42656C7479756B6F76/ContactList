using ContactList.Domain.ValueObjects.Contact;

namespace ContactList.Domain;

public record ContactEntityV1
{
    private readonly Id _id;
    
    private readonly Name _name;
    
    private readonly PhoneNumber _phoneNumber;
    
    private readonly PersonId _personId;

    public long Id
    {
        get => _id;
        init => _id = value;
    }

    public required string Name
    {
        get => _name;
        init => _name = value;
    }

    public required string PhoneNumber
    {
        get => _phoneNumber;
        init => _phoneNumber = value;
    }

    public required long PersonId
    {
        get => _personId;
        init => _personId = value;
    }

    public required DateTimeOffset CreatedAt { get; init; }
}