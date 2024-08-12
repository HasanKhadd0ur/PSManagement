using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PSManagement.Application.Contracts.Providers;
using PSManagement.Application.Contracts.SyncData;
using PSManagement.Infrastructure.Settings;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Infrastructure.BackgroundServcies
{
    public class BackgroundJobSyncEmployees: BackgroundService
    {
        private readonly IDateTimeProvider _timeProvider;

        private readonly IServiceScopeFactory _scopeFactory;
        private readonly int _syncIntervalInMinutes;
        public BackgroundJobSyncEmployees(
            IDateTimeProvider timeProvider,
            IOptions<EmployeesSyncJobSettings> settings,
            IServiceScopeFactory scopeFactory)
        {
            _timeProvider = timeProvider;
            _syncIntervalInMinutes = settings.Value.SyncIntervalInMinutes;
            _scopeFactory = scopeFactory;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // This loop will run until the application shuts down
            while (!stoppingToken.IsCancellationRequested)
            {

                try
                {
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        // Resolve the scoped IEmployeesRepository
                        var dataProvider = scope.ServiceProvider.GetRequiredService<IEmployeesProvider>();
                        var syncService = scope.ServiceProvider.GetRequiredService<ISyncEmployeesService>();

                        // Now you can use the repository to sync employees data
                        SyncResponse response = await syncService.SyncEmployees(dataProvider);

                        Console.WriteLine("A Data sync for Employees Occured At " +response.SyncDate +"\n The number of new Employees are "+response.SyncDataCount );

                    }

                }
                catch (Exception ex)
                {
                }

                // Wait for an hour before running the task again
                await Task.Delay(TimeSpan.FromMinutes(_syncIntervalInMinutes), stoppingToken);
            }

        }
    }
}
