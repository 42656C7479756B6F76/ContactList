namespace ContactList.Domain.ValueObjects.Contact;

public readonly struct PersonId
{
    private PersonId(long value)
    {
        if (value <= 0) throw new ArgumentException("PersonId must be greater than zero.", nameof(value));
        _value = value;
    }

    private readonly long _value;

    public static implicit operator long(PersonId personId)
    {
        return personId._value;
    }

    public static implicit operator PersonId(long value)
    {
        return new PersonId(value);
    }

    public override string ToString()
    {
        return _value.ToString();
    }
}