using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PSManagement.Application.Contracts.Authentication;
using MediatR;
using System.Reflection;
using AutoMapper;
using PSManagement.Application.Mappers;

namespace PSManagement.Application.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddMediatR();
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            services.AddAutoMapper(typeof(CustomerMapperConfiguration));

            return services;
        }


    }
}

