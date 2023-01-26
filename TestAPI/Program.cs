using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TestAPI;
using TestAPI.Interfaces.Repositories;
using TestAPI.Interfaces.Services;
using TestAPI.Repositories;
using TestAPI.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

//Repositories
builder.Services.AddTransient<ICityRepository, CityRepository>();
builder.Services.AddTransient<ICountryRepository, CountryRepository>();
//builder.Services.AddTransient<ICountryService, CountryService>();

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
