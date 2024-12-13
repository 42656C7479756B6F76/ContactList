namespace ContactList.Domain.ValueObjects.Contact;

public record Name
{
    private Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("FirstName cannot be null or empty.", nameof(value));
        Value = value;
    }

    private string Value { get; }

    public static implicit operator Name(string value)
    {
        return new Name(value);
    }

    public static implicit operator string(Name name)
    {
        return name.Value;
    }

    public override string ToString()
    {
        return Value;
    }
}