using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PSManagement.Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services;
        }

    }
}
