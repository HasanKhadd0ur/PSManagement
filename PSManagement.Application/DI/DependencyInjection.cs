using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PSManagement.Application.Contracts.Authentication;
using MediatR;
using System.Reflection;
using AutoMapper;
using PSManagement.Application.Mappers;
using FluentValidation;
using PSManagement.Application.Behaviors.ValidationBehavior;
using PSManagement.Application.Behaviors.LoggingBehavior;
using MapperConfiguration = PSManagement.Application.Mappers.MapperConfiguration;

namespace PSManagement.Application.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddMediatR();


            services.AddMediatR(typeof(DependencyInjection).Assembly);
            // Register the pipeline behaviors explicitly
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            // Register FluentValidation validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            
            services.AddAutoMapper(cfg => {
                cfg.AddProfile<MapperConfiguration>();
            });

            return services;
        }


    }
}

