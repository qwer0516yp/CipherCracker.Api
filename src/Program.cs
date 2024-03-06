using CipherCracker.Api;
using CipherCracker.Api.Examples;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.ExampleFilters();
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "CipherCracker API", Version = "v1" });
});

builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly()); // Add Swagger examples

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "CipherCracker.Api v1");
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.RegisterWeatherSampleModuleEndpoints();
app.RegisterUtilityModuleEndpoints();
app.RegisterAesModuleEndpoints();

app.Run();
