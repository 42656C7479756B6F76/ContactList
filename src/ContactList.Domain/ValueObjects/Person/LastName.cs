namespace ContactList.Domain.ValueObjects.Person;

public record LastName
{
    private LastName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Phone number cannot be null or empty.", nameof(value));
        Value = value;
    }

    private string Value { get; }

    public static implicit operator string(LastName lastName)
    {
        return lastName.Value;
    }

    public static implicit operator LastName(string value)
    {
        return new LastName(value);
    }

    public override string ToString()
    {
        return Value;
    }
}