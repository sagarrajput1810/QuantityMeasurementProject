// QuantityMeasurementSystem/Program.cs
using Microsoft.EntityFrameworkCore;
using QuantityMeasurement.Business;
using QuantityMeasurement.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Entity Framework Core with SQL Server
// Update the connection string to match your local SQLEXPRESS instance
var connectionString = "Server=.\\SQLEXPRESS;Database=QuantityMeasurementDB;Trusted_Connection=True;TrustServerCertificate=True;";
builder.Services.AddDbContext<MeasurementDbContext>(options =>
    options.UseSqlServer(connectionString));

// Register Dependency Injection for your N-Tier architecture
builder.Services.AddScoped<IMeasurementRepository, MeasurementDatabaseRepository>();
builder.Services.AddScoped<IMeasurementBusiness, MeasurementBusiness>();

// Configure Swagger/OpenAPI for UC17 documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();