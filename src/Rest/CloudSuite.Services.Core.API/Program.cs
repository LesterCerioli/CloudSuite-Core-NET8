using AutoMapper;
using CloudSuite.Infrastructure.CrossCutting.Middlewares;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddMediatR();
//builder.Services.AddLogger();
//builder.Services.AddHealthCheckConfigurations();
//builder.Services.AddSwaggerDocVersion();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
//builder.Services.AddDatabaseConfiguration(builder.Configuration);

var configuration = new MapperConfiguration(cfg =>
{
});


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
