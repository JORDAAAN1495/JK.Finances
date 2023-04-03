var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, logger) =>
{
    logger.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration
    .Sources
    .Clear();

builder.Configuration
    .AddJsonFile("appsettings.json", false, true);

builder.Configuration
    .AddEnvironmentVariables()
    .AddUserSecrets(Assembly.GetExecutingAssembly(), true);

builder.Services.AddDataAccess();

var app = builder.Build();

app.RegisterSwagger();

app.UseHttpsRedirection();

app.MapAccountEndpoints();

await app.RunAsync();