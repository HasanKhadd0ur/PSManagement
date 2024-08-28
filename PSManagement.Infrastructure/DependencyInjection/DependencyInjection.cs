using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PSManagement.Application.Contracts.Authentication;
using PSManagement.Application.Contracts.Authorization;
using PSManagement.Application.Contracts.Email;
using PSManagement.Application.Contracts.Occupancy;
using PSManagement.Application.Contracts.Providers;
using PSManagement.Application.Contracts.Storage;
using PSManagement.Application.Contracts.SyncData;
using PSManagement.Application.Contracts.Tokens;
using PSManagement.Infrastructure.Authentication;
using PSManagement.Infrastructure.BackgroundServcies;
using PSManagement.Infrastructure.Services.Authentication;
using PSManagement.Infrastructure.Services.Authorization;
using PSManagement.Infrastructure.Services.Email;
using PSManagement.Infrastructure.Services.Occupancy;
using PSManagement.Infrastructure.Services.Providers;
using PSManagement.Infrastructure.Services.Storage;
using PSManagement.Infrastructure.Settings;
using PSManagement.Infrastructure.Tokens;

namespace PSManagement.Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureSevices(this IServiceCollection services,IConfiguration configuration)
        {
            services
                .AddAuthentication(configuration)
                .AddAuthorization()
                .AddServices(configuration)
                .AddBackgroundServices(configuration)
                .AddCronJobs();
            
            return services;
        }

        #region Add Servcies 
        private static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<FileServiceSettings>(configuration.GetSection(FileServiceSettings.SectionName));

            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IEmployeesProvider, EmployeesProvider>();
            services.AddScoped<ICurrentUserProvider,CurrentUserProvider>();

            services.AddScoped<IFileService,FileService>();
            services.AddScoped<IEmailService,EmailService>();
            return services;
        }

        #endregion Add Servcies 

        #region Background jobs 
        private static IServiceCollection AddBackgroundServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<EmployeesSyncJobSettings>(configuration.GetSection(EmployeesSyncJobSettings.SectionName));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ISyncEmployeesService, SyncEmployeesService>();
            services.AddScoped<IOccupancySystemNotifier,OccupancySystemNotifier>();   
            services.AddHostedService<CronJobSyncEmployees>();

            return services;
        }

        #endregion Background jobs 

        #region Authorization 
        private static IServiceCollection AddAuthorization(this IServiceCollection services)
        {
            services.AddScoped<IUserRoleService, UserRolesService>();
            services.AddScoped<IRoleService, RoleService>();

            return services;
        }
        #endregion Authorization 

        #region Authentication 
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
        #endregion Authentication 

        #region Cron Jobs
        private static IServiceCollection AddCronJobs(this IServiceCollection services) {

            return services;
        
        }
        #endregion
    }
}
