using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PSManagement.Domain.Customers.Repositories;
using PSManagement.Domain.Identity.Repositories;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.Infrastructure.Persistence.Repositories.CustomerRepository;
using PSManagement.Infrastructure.Persistence.Repositories.ProjectRepository;
using PSManagement.Infrastructure.Persistence.Repositories.UserRepository;
using PSManagement.Infrastructure.Persistence.UoW;
using PSManagement.SharedKernel.Interfaces;

namespace PSManagement.Infrastructure.Persistence.DI
{
    public static class DependencyInjection
    {
        
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ICustomersRepository, CustomersReposiotry>();
            services.AddScoped<IProjectsRepository, ProjectsRepository>();



            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        
    }
}
