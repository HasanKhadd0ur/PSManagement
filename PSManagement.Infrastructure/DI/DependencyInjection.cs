using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PSManagement.Application.Common.Services;
using PSManagement.Application.Contracts.Authentication;
using PSManagement.Application.Contracts.Authorization;
using PSManagement.Infrastructure.Authentication;
using PSManagement.Infrastructure.Persistence.Repositories.UserRepository;
using PSManagement.Infrastructure.Services;
using PSManagement.Infrastructure.Services.Authentication;
using PSManagement.Infrastructure.Tokens;

namespace PSManagement.Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services
                .AddAuthentication(configuration)
                .AddAuthorization()
                .AddServices()
                .AddPersistence();

            
            return services;
        }
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            return services;
        }

        private static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            //services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source = CleanArchitecture.sqlite"));

            //services.AddScoped<IRemindersRepository, RemindersRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();

            return services;
        }

        private static IServiceCollection AddAuthorization(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSetting>(configuration.GetSection(JwtSetting.Section));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services
                .ConfigureOptions<JwtBearerTokenValidationConfiguration>()
                .AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();

            return services;
        }
    }
}
