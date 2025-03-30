using Domain.UseCases;
using Domain.UseCases.Implementations;
using DotNetEnv;
using Infraestructure.Extensions;

Env.Load("../.env");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();

// Infraestructure
builder.Services.AddInfraestructure(builder.Configuration);

// Use cases (Domain)
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginUseCase).Assembly));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "sist-gestion-backend", Version = "v1" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "sist-gestion-backend v1");
    c.RoutePrefix = string.Empty;
}); 

app.UseHttpsRedirection();
app.MapControllers(); 
app.Run();