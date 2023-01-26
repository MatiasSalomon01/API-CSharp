using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TestAPI;
using TestAPI.Interfaces.Repositories;
using TestAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

//Repositories
builder.Services.AddScoped<ICityRepository, CityRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//4
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("TestDB")));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
