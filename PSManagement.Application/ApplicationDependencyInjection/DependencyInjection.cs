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

            services.AddMyMediatR()
                .AddMappers();

            

            return services;
        }

        #region Mediator
        private static IServiceCollection AddMyMediatR(this IServiceCollection services) {

            services.AddMediatR(typeof(DependencyInjection).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


            return services;
        }
        #endregion Mediator


        #region Mappers 
        private static IServiceCollection AddMappers(this IServiceCollection services)
        {

            services.AddAutoMapper(cfg => {
                cfg.AddProfile<MapperConfiguration>();
                cfg.AddProfile<ProjectDTOMapperConfiguration>();
                cfg.AddProfile<FinanialSpendingDTOMapperConfiguration>();

            });


            return services;
        }

        #endregion Mappers

    }
}

