using PSManagement.Domain.Tracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Contracts.Occupancy
{
    public interface IOccupancySystemNotifier
    {
        public Task SendEmployeeOccupancyNotification(EmployeeTrack employeeTrack);
    }
}
