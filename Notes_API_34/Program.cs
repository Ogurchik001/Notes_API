using Microsoft.EntityFrameworkCore;
using Notes_API_34.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<FurnitureManufacturingContext>(options => options.UseSqlServer("Server=DESKTOP-HJIL55T\\SQLEXPRESS;Database=FurnitureManufacturing;TrustServerCertificate=true;Trusted_Connection=true"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
