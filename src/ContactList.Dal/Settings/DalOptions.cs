namespace ContactList.Dal.Settings;

public record DalOptions
{
    public required string PostgresConnectionString { get; init; } = string.Empty;
}