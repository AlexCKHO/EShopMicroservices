

var builder = WebApplication.CreateBuilder(args);



var assembly = typeof(Program).Assembly;

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
}
);

builder.Services.AddValidatorsFromAssembly(assembly);

// Add services to the container.
builder.Services.AddCarter();

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database"));
    
}
).UseLightweightSessions();

// Add the CustomExceptionHandler into Dependance injection toolbox
builder.Services.AddExceptionHandler<CustomExcetionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter();


// Use the CustomExceptionHandler to handle all incoming Exception
app.UseExceptionHandler(options => { });


app.Run();




