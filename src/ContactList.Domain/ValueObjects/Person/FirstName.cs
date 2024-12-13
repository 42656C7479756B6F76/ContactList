namespace ContactList.Domain.ValueObjects.Person;

public record FirstName
{
    private FirstName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("FirstName cannot be null or empty.", nameof(value));
        Value = value;
    }

    private string Value { get; }

    public static implicit operator string(FirstName firstName)
    {
        return firstName.Value;
    }

    public static implicit operator FirstName(string value)
    {
        return new FirstName(value);
    }

    public override string ToString()
    {
        return Value;
    }
}