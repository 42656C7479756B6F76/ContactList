namespace ContactList.Domain.ValueObjects.Contact;

public readonly struct Id
{
    private Id(long value)
    {
        if (value <= 0) throw new ArgumentException("PersonId must be greater than zero.", nameof(value));
        _value = value;
    }

    private readonly long _value;

    public static implicit operator long(Id personId)
    {
        return personId._value;
    }

    public static implicit operator Id(long value)
    {
        return new Id(value);
    }

    public override string ToString()
    {
        return _value.ToString();
    }
}