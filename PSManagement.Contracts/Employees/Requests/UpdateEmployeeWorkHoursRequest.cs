using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Contracts.Employees.Requests
{
    public record UpdateEmployeeWorkHoursRequest(
       int EmployeeId,
       int WorkingHour);
}
