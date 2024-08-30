using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PSManagement.Api.Mappers;

namespace PSManagement.Presentaion.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services
                .AddMapper()
                .AddMyControllers()
                ;

            return services;
        }

        #region Configure controllers 
        private static IServiceCollection AddMyControllers(this IServiceCollection services)
        {

            services
                .AddControllers()
                .AddApplicationPart(Presentation.AssemblyReference.Assembly);

            return services;
        }
        #endregion Configure controllers

        #region Mappers 
        private static IServiceCollection AddMapper(this IServiceCollection services)
        {

            services.AddScoped<Mapper>();

            services.AddAutoMapper(cfg => {

                cfg.AddProfile<CustomerMapperConfiguration>();
                cfg.AddProfile<ProjectMapperConfiguration>();
                cfg.AddProfile<MappersConfigurations>();
                cfg.AddProfile<EmployeeMapperConfiguration>();
            });


            return services;

        }

        #endregion Mappers 
    }
}
