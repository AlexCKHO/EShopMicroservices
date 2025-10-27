
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Infrastructure – EF Core
//Application – MediatR
//API – Carter, HealthChecks, ...
//


builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration); // From DependencyInjection.cs



var app = builder.Build();

// Configure the HTTP request pipeline, Configuring the middleware pipeline (Runtime phase)

app.UseApiServices();

if (app.Environment.IsDevelopment())
{

    await app.InitialiseDatabaseAsync();

}

app.Run();
