using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PSManagement.Application.Common.Services;
using PSManagement.Application.Contracts.Authentication;
using PSManagement.Infrastructure.Authentication;
using PSManagement.Infrastructure.Services;
using PSManagement.Infrastructure.Services.Authentication;

namespace PSManagement.Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<JwtSetting>(configuration.GetSection(JwtSetting.Section));
            services.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IAuthenticationService,AuthenticationService>();
            return services;
        }

    }
}
