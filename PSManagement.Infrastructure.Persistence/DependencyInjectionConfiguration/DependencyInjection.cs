using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PSManagement.Domain.Customers.Repositories;
using PSManagement.Domain.Employees.Repositories;
using PSManagement.Domain.FinancialSpends.Entities;
using PSManagement.Domain.FinincialSpending.Repositories;
using PSManagement.Domain.Identity.Repositories;
using PSManagement.Domain.Projects.Builders;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.Domain.Steps.Repositories;
using PSManagement.Infrastructure.Persistence.Repositories.Base;
using PSManagement.Infrastructure.Persistence.Repositories.CustomerRepository;
using PSManagement.Infrastructure.Persistence.Repositories.EmployeeRepository;
using PSManagement.Infrastructure.Persistence.Repositories.ProjectRepository;
using PSManagement.Infrastructure.Persistence.Repositories.StepRepository;
using PSManagement.Infrastructure.Persistence.Repositories.TrackRepository;
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
            services
                .AddBuilders()
                .AddDataContext(configuration)
                .AddRepositories()
                .AddUOW();

            return services;
        }

        #region Register Builders 
        private static IServiceCollection AddBuilders(this IServiceCollection services)
        {

            services.AddScoped<ProjectBuilder>();
            return services;

        }
        #endregion Register Builders 

        #region Register UOW 

        private static IServiceCollection AddUOW(this IServiceCollection services) {

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;        
        }
        #endregion Register UOW 

        #region Register Repositories
        private static IServiceCollection AddRepositories(this IServiceCollection services) {

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ICustomersRepository, CustomersReposiotry>();
            services.AddScoped<IProjectsRepository, ProjectsRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IEmployeesRepository, EmployeesRespository>();
            services.AddScoped<IStepsRepository, StepsRepository>();
            services.AddScoped<IFinancialSpendingRepository, FinancialSpendingRepository>();
            services.AddScoped<ITracksRepository, TracksRepository>();
            services.AddScoped<IProjectTypesRepository, ProjectsTypesRepository>();

            return services;
        
        }

        #endregion Register Repositoryies

        #region Register Data context 
        private static IServiceCollection AddDataContext(this IServiceCollection services ,IConfiguration configuration) {

            services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;

        }

        #endregion Register Data Context 
    }
}
