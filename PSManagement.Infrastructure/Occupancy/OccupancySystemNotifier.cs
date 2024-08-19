using Microsoft.Extensions.Logging;
using PSManagement.Application.Contracts.Occupancy;
using PSManagement.Domain.Tracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Infrastructure.Services.Occupancy
{
    public class OccupancySystemNotifier : IOccupancySystemNotifier
    {
        private readonly ILogger<EmployeeTrack> _logger;

        public OccupancySystemNotifier(ILogger<EmployeeTrack> logger)
        {
            _logger = logger;
        }

        public Task SendEmployeeOccupancyNotification(EmployeeTrack employeeTrack)
        {
            _logger.LogInformation("employee track sended");
            return Task.CompletedTask;

        }
    }
}
