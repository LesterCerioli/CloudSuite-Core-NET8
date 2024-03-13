using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Contracts.PasswordGeneratorContext;
using CloudSuite.Infrastructure.Context;
using CloudSuite.Infrastructure.CrossCutting.DependencyInjector;
using CloudSuite.Infrastructure.CrossCutting.HealthChecks;
using CloudSuite.Infrastructure.CrossCutting.Middlewares;
using CloudSuite.Infrastructure.Repositories;
using CloudSuite.Infrastructure.Repositories.PasswordGeneratorContext;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.Services.Contracts.PasswirdGeneratorContext;
using CloudSuite.Modules.Application.Services.Implementations;
using CloudSuite.Modules.Application.Services.Implementations.PasswordGeneratorContext;
using CloudSuite.Services.Core.API.Configurations;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Mediator;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CoreDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONECTIONSTRING")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediator();
builder.Services.AddLogger();
//builder.Services.AddTwilioServices();
builder.Services.AddHealthCheckConfigurations();
builder.Services.AddSwaggerDocVersion();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddDbContext<CoreDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONECTIONSTRING")));


var configuration = new MapperConfiguration(cfg =>
{
});



builder.Services.AddTransient<IAddressAppService, AddressAppService>();
builder.Services.AddTransient<ICityAppService, CityAppService>();
builder.Services.AddTransient<ICompanyAppService, CompanyAppService>();
builder.Services.AddTransient<ICountryAppService, CountryAppService>();
builder.Services.AddTransient<IDistrictAppService, DistrictAppService>();
builder.Services.AddTransient<IEmailAppService, EmailAppService>();
builder.Services.AddTransient<IMediaAppService, MediaAppService>();
builder.Services.AddTransient<IStateAppService, StateAppService>();
builder.Services.AddTransient<IUserAppService, UserAppService>();
builder.Services.AddTransient<IVendorAppService, VendorAppService>();
builder.Services.AddTransient<IPasswordAppService, PasswordAppService>();
builder.Services.AddTransient<IMediator, Mediator>();
builder.Services.AddTransient<IAddressRepository, AddressRepository>();
builder.Services.AddTransient<ICityRepository, CityRepository>();
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<ICountryRepository, CountryRepository>();
builder.Services.AddTransient<IDistrictRepository, DistrictRepository>();
builder.Services.AddTransient<IEmailRepository, EmailRepository>();
builder.Services.AddTransient<IMediaRepository, MediaRepository>();
builder.Services.AddTransient<IStateRepository, StateRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IVendorRepository, VendorRepository>();
builder.Services.AddTransient<IPasswordRepository, PasswordRepository>();
builder.Services.AddTransient<IMediatorHandler, MediatorHandler>();
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


if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	app.UseHttpLogging();
}
//app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors(x => x
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();






