var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// Cpmfigure the HTTP request pipeline.

app.Run();
