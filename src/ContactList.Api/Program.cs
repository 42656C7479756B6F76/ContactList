using ContactList.Api.Middlewares;
using ContactList.Bll.Extensions;
using ContactList.Dal.Extensions;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services
    .AddDalInfrastructure(builder.Configuration)
    .AddDalRepositories()
    .AddBllServices();

services
    .AddBllValidators()
    .AddFluentValidationAutoValidation();

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.MapControllers();

app.UseMiddleware<ErrorMiddleware>();

app.MigrateUp();

app.Run();