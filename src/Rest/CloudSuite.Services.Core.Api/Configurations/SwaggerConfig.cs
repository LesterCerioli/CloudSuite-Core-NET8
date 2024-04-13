using Microsoft.OpenApi.Models;
namespace CloudSuite.Services.Core.API.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
		{
			if (services == null) throw new ArgumentNullException(nameof(services));

			services.AddSwaggerGen(s =>
			{
				s.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "Ache Pacientes",
					Description = "CloudSuite Core API Swagger surface",
					Contact = new OpenApiContact { Name = "Lester Cerioli" }

				});

				s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Description = "Input the JWT like: Bearer {your token}",
					Name = "Authorization",
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey
				});

				s.AddSecurityRequirement(new OpenApiSecurityRequirement
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference
							{
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							}
						},
						new string[] {}
					}
				});

			});
		}

		public static void UseSwaggerSetup(this IApplicationBuilder app)
		{
			if (app == null) throw new ArgumentNullException(nameof(app));

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
			});
		}
        
    }
}