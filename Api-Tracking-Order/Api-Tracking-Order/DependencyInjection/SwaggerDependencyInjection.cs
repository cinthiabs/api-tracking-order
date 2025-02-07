using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Api_Tracking_Order.DependencyInjection
{
    public static partial class SwaggerDependencyInjection
    {
        public static void AddSwaggerDocumentation(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API Tracking Order",
                    Version = "v1",
                    Description = "WEB API - Responsible for inserting and returning tracking.",

                    Contact = new OpenApiContact()
                    {

                        Name = "Cinthia Barbosa",
                        Email = "cinthiabarbosa8d@outlook.com",
                        Url = new Uri("https://github.com/cinthiabs")
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer, Example: Bearer [your Token]",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                        Array.Empty<string>()
                    }
                });
            });
        }
    }
}
