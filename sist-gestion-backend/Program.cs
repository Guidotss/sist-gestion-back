using sist_gestion_backend.Context;
using DotNetEnv; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
Env.Load();
builder.Services.AddOpenApi();
builder.Services.AddControllers();


builder.Services.AddSingleton<DapperContext>(); 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}



app.UseHttpsRedirection();
app.MapControllers(); 
app.Run();