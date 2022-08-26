using MiniatureParakeet.Core.Interface;
using MiniatureParakeet.Core.Repositories;
using MiniatureParakeet.Core.Service;
using MiniatureParakeet.Core.Services;
using MiniatureParakeet.Infrastructure;
using MiniatureParakeet.Infrastructure.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repopositories and data access
builder.Services.AddDbContext<RegisterDataContext>();
builder.Services.AddTransient<ICityRepository, CityDataAccess>();
builder.Services.AddTransient<ICountryRepository, CountryDataAccess>();
builder.Services.AddTransient<ICurrencyRepository, CurrencyDataAccess>();
builder.Services.AddTransient<IStateRepository, StateDataAccess>();
builder.Services.AddTransient<ITerminalRepository, TerminalDataAccess>();


// services
builder.Services.AddTransient<ICityService, CityService>();
builder.Services.AddTransient<ICountryService, CountryService>();
builder.Services.AddTransient<ICurrencyService, CurrencyService>();
builder.Services.AddTransient<IStateService, StateService>();
builder.Services.AddTransient<ITerminalService, TerminalService>();


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
