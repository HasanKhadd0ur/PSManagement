using PSManagement.SharedKernel.DomainErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Employees.DomainErrors
{
    public class EmployeesErrors
    {
        public static readonly DomainError EmployeeUnExist = new("Employees.UnExist", "The Provided Credential Dosent match any employee.  ");

    }
}
