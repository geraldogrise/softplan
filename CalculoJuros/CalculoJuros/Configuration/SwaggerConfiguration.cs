using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;

namespace CalculoJuros.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfig(this IServiceCollection services, IConfiguration configuration)
        {
            var swaggerOptions = new SwaggerOptions();
            new ConfigureFromConfigurationOptions<SwaggerOptions>(configuration.GetSection("SwaggerOptions"))
                .Configure(swaggerOptions);

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Sistema de Cálculo de Juros",
                        Version = "v1",
                        Description = "SCJ API",
                        Contact = new OpenApiContact
                        {
                            Name = "Geraldo Grise",
                            Url = new Uri("http://grisecorp.com")
                        }
                    });
            });

        }
    }
}