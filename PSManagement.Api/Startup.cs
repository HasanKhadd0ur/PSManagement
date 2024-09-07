using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PSManagement.Infrastructure.DI;
using PSManagement.Application.DI;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSManagement.Infrastructure.Persistence.DI;
using PSManagement.Api.DI;
using PSManagement.Presentation.DependencyInjection;
using PSManagement.Api.Middleware.ExceptionHandler;
using PSManagement.Api.Settings;
using PSManagement.Api.Configurations;

namespace PSManagement.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
       
        public void ConfigureServices(IServiceCollection services)
        {
            // adding dependency injection 
            services
                .AddAPI(Configuration)
                .AddPresentation()
                .AddApplication()
                .AddPersistence(Configuration)
                .AddInfrastructureSevices(Configuration);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PSManagement.Api v1"));
            }
            else {

                app.UseMiddleware<ExceptionHandlingMidllerware>();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            
            app.UseMyCors();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}
