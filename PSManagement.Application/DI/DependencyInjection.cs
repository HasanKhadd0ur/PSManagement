using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PSManagement.Application.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services;
        }


    }
}

