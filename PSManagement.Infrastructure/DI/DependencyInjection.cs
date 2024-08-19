﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
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
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services
                .AddAuthentication(configuration)
                .AddAuthorization()
                .AddServices()
                .AddBackgroundServices(configuration);

            
            return services;
        }
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped<IEmployeesProvider, EmployeesProvider>();
            services.AddScoped<ICurrentUserProvider,CurrentUserProvider>();

            services.AddScoped<IFileService,FileService>();
            services.AddScoped<IEmailService,EmailService>();
            return services;
        }
        private static IServiceCollection AddBackgroundServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<EmployeesSyncJobSettings>(configuration.GetSection("EmpoyeesSyncJobSettings"));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ISyncEmployeesService, SyncEmployeesService>();
            services.AddScoped<IOccupancySystemNotifier,OccupancySystemNotifier>();   
            services.AddHostedService<BackgroundJobSyncEmployees>();

            return services;
        }


        private static IServiceCollection AddAuthorization(this IServiceCollection services)
        {
            services.AddScoped<IUserRoleService, UserRolesService>();
            services.AddScoped<IRoleService, RoleService>();

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
