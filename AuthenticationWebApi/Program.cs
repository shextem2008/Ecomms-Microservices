using JwtAuthenticationManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Configure the HTTP request pipeline.
builder.Services.AddSingleton<JwtTokenHandler>();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
