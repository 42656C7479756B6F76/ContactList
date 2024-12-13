namespace ContactList.Domain.ValueObjects.Contact;

public record PhoneNumber
{
    private PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Phone number cannot be null or empty.", nameof(value));
        Value = value;
    }

    private string Value { get; }

    public static implicit operator string(PhoneNumber phoneNumber)
    {
        return phoneNumber.Value;
    }

    public static implicit operator PhoneNumber(string value)
    {
        return new PhoneNumber(value);
    }

    public override string ToString()
    {
        return Value;
    }
}