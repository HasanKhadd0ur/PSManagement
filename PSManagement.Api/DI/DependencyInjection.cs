using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PSManagement.Api.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            return services;
        }


    }
}
