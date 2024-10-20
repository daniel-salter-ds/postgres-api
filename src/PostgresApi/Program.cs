using Microsoft.EntityFrameworkCore;
using PostgresApi.Data;
using PostgresApi.Services;

var builder = WebApplication.CreateBuilder(args);


// ----- Add services to the container. -----

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Add support for controllers
builder.Services.AddControllers();

// Register AppDbContext and configure it to use PostgreSQL.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add resource-specific services
builder.Services.AddScoped<WeatherForecastService>();
builder.Services.AddScoped<ClientService>();


// ----- Configure application -----

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// Enable attribute routing by mapping controller actions
app.MapControllers();


// ----- Run application -----

await app.RunAsync();
