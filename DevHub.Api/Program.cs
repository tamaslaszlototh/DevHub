using DevHub.Api;
using DevHub.Domain;
using DevHub.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfrastructureLayerServices(builder.Configuration)
    .AddApplicationLayerServices()
    .AddDomainLayerServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();