using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PSManagement.Domain.Customers.Repositories;
using PSManagement.Domain.Employees.Repositories;
using PSManagement.Domain.Identity.Repositories;
using PSManagement.Domain.Projects.Builders;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.Infrastructure.Persistence.Repositories.Base;
using PSManagement.Infrastructure.Persistence.Repositories.CustomerRepository;
using PSManagement.Infrastructure.Persistence.Repositories.EmployeeRepository;
using PSManagement.Infrastructure.Persistence.Repositories.ProjectRepository;
using PSManagement.Infrastructure.Persistence.Repositories.UserRepository;
using PSManagement.Infrastructure.Persistence.UoW;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Repositories;

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
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IEmployeesRepository, EmployeesRespository>();


            services.AddScoped<ProjectBuilder>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        
    }
}
