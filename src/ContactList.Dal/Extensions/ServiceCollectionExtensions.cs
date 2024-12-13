using ContactList.Dal.Infrastructure;
using ContactList.Dal.Repositories;
using ContactList.Dal.Repositories.Interfaces;
using ContactList.Dal.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContactList.Dal.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDalInfrastructure(
        this IServiceCollection services,
        IConfigurationRoot config)
    {
        services.Configure<DalOptions>(config.GetSection(nameof(DalOptions)));

        Postgres.MapCompositeTypes();

        Postgres.AddMigrations(services);

        return services;
    }

    public static IServiceCollection AddDalRepositories(
        this IServiceCollection services)
    {
        AddPostgresRepositories(services);
        return services;
    }

    private static void AddPostgresRepositories(IServiceCollection services)
    {
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IContactRepository, ContactRepository>();
    }
}