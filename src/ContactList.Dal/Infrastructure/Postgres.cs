using ContactList.Dal.Settings;
using ContactList.Domain;
using ContactList.Domain.ValueObjects.Person;
using Dapper;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Npgsql;
using Npgsql.NameTranslation;

namespace ContactList.Dal.Infrastructure;

public static class Postgres
{
    private static readonly INpgsqlNameTranslator Translator = new NpgsqlSnakeCaseNameTranslator();

    public static void MapCompositeTypes()
    {
        var mapper = NpgsqlConnection.GlobalTypeMapper;
        DefaultTypeMap.MatchNamesWithUnderscores = true;
        
        mapper.MapComposite<ContactEntityV1>("contacts_v1", Translator);
        mapper.MapComposite<PersonEntityV1>("persons_v1", Translator);
    }

    public static void AddMigrations(IServiceCollection services)
    {
        services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb.AddPostgres()
                .WithGlobalConnectionString(s =>
                {
                    var cfg = s.GetRequiredService<IOptions<DalOptions>>();
                    return cfg.Value.PostgresConnectionString;
                })
                .ScanIn(typeof(Postgres).Assembly).For.Migrations()
            )
            .AddLogging(lb => lb.AddFluentMigratorConsole());
    }
}