using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PSManagement.Application.Contracts.Authentication;
using MediatR;
using System.Reflection;
using Microsoft.OpenApi.Models;
using System;
using AutoMapper;

namespace PSManagement.Api.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAPI(this IServiceCollection services)
        {

            services
                .AddApiSwagger()
                .AddApiCors()
                .AddMyMiddlewares()
                ;

            return services;
        }

        
        #region Api Docs Swagger
        private static IServiceCollection AddApiSwagger(this IServiceCollection services)
        {


            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "PSManagement.Api", Version = "v1" });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
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

            return services;
        }
        #endregion  Api Docs Swagger

        #region Cors
        private static IServiceCollection AddApiCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {

                options.AddPolicy("AllowFrontend",
                    builder => builder
                        .WithOrigins("http://localhost:4200") // Add your frontend URL here
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());

                options.AddPolicy("AllowHiast",
                    builder => builder
                        .WithOrigins("**.hiast.edu.sy/") // Add your frontend URL here
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials());
                        

            });


            return services;
        }
        #endregion Cors

        #region Middlewares 

        private static IServiceCollection AddMyMiddlewares(this IServiceCollection services) {

            return services;
        }
        #endregion Middlewares 


    }


}

