using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Infrastructure.Context;
using CloudSuite.Infrastructure.CrossCutting.DependencyInjector;
using CloudSuite.Infrastructure.CrossCutting.HealthChecks;
using CloudSuite.Infrastructure.CrossCutting.Middlewares;
using CloudSuite.Infrastructure.Repositories;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.Services.Implementations;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Mediator;
using CloudSuite.Services.Core.API.Configurations;
using MediatR;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure DbContext with connection string
builder.Services.AddDbContext<CoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddMediator();
builder.Services.AddLogger();
builder.Services.AddHealthCheckConfigurations();
//builder.Services.AddDatabaseConfiguration(builder.Configuration);




var configuration = new MapperConfiguration(cfg =>
{
    // Mapper configurations
});

builder.Services.AddSingleton<IMapper>(configuration.CreateMapper());
builder.Services.AddTransient<IAddressAppService, AddressAppService>();
builder.Services.AddTransient<ICityAppService, CityAppService>();
builder.Services.AddTransient<ICompanyAppService, CompanyAppService>();
builder.Services.AddTransient<ICountryAppService, CountryAppService>();
builder.Services.AddTransient<IDistrictAppService, DistrictAppService>();
builder.Services.AddTransient<IMediaAppService, MediaAppService>();
builder.Services.AddTransient<IStateAppService, StateAppService>();

builder.Services.AddTransient<IMediator, Mediator>();
builder.Services.AddTransient<IMediatorHandler, MediatorHandler>();
builder.Services.AddTransient<IAddressRepository, AddressRepository>();
builder.Services.AddTransient<ICityRepository, CityRepository>();
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<ICountryRepository, CountryRepository>();
builder.Services.AddTransient<IDistrictRepository, DistrictRepository>();
builder.Services.AddTransient<IMediaRepository, MediaRepository>();
builder.Services.AddTransient<IStateRepository, StateRepository>();
builder.Services.AddSingleton<IMapper>(configuration.CreateMapper());

builder.Services.AddCors(options =>
{
    options.AddPolicy("my-cors",
                          policy =>
                          {
                              policy
                              .AllowAnyOrigin()
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                          });
});

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