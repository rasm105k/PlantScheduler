using PlantScheduler.Api.Models;
using PlantScheduler.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(ctx =>
{
    var plantDbConnectionString = builder.Configuration["PlantConnectionString"]!;
    return new PlantRepository(plantDbConnectionString);
});

builder.Services.AddCors();

builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.MapOpenApi();

app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyHeader()
          .AllowAnyMethod());

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/openapi/v1.json", "v1");
});

app.Run();
