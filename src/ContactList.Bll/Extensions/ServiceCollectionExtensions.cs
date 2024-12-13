using ContactList.Bll.Models.Contact;
using ContactList.Bll.Services;
using ContactList.Bll.Services.Interfaces;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ContactList.Bll.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBllServices(
        this IServiceCollection services)
    {
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<IContactService, ContactService>();

        return services;
    }

    public static IServiceCollection AddBllValidators(
        this IServiceCollection services)
    {
        return services
            .AddValidatorsFromAssemblyContaining<AddContactModel>();
    }
}