using Microsoft.EntityFrameworkCore;
using ProductWebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

/* Database Context Dependency Injection */
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_ROOT_PASSWORD");


//var dbHost2 = Environment.GetEnvironmentVariable("DB_HOST");
//var dbName2 = Environment.GetEnvironmentVariable("DB_NAME");
//var dbPassword2 = Environment.GetEnvironmentVariable("DB_ROOT_PASSWORD");

//for local machine
//var dbHost = "localhost";
//var dbName = "Ecoms_b_Product";
//var dbPassword = "entx!2003n";

var connectionString = $"server={dbHost};port=3306;database={dbName};user=root;password={dbPassword}";
var connectionStringPercona = $"Server={dbHost}; uid=root; pwd={dbPassword}; database={dbName}";

//"DefaultConnectionPercona": "Server=127.0.0.1; uid=root; pwd=admin123; database=TensectMy"
builder.Services.AddDbContext<ProductDbContext>(o => o.UseMySQL(connectionString));
/* ===================================== */

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
