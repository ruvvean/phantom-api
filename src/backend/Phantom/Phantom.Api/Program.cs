using Phantom.Api.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: false);

IServiceCollection services = builder.Services;

services.AddOpenApi();

services.AddConfiguredOptions(builder.Configuration, builder.Environment.EnvironmentName);

WebApplication app = builder.Build();

app.MapOpenApi();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/openapi/v1.json", "Phantom API v1");
    c.RoutePrefix = "";
});

await app.RunAsync();

