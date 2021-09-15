using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace PetClinic.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Clean Architecture - PetClinic",
                });

                options.AddSecurityDefinition("jwt_auth", new OpenApiSecurityScheme
                {
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "Example: Bearer {ACCESS TOKEN} to access this API",
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "jwt_auth",
                                Type = ReferenceType.SecurityScheme
                            },
                        }, new string[] {}
                    },
                });

                options.CustomSchemaIds(type => type.ToString());
            });
        }
    }
}
