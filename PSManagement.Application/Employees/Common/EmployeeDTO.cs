using PSManagement.Domain.Employees.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Employees.Common
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public int HIASTId { get; set; }
        public int UserId { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public WorkInfo WorkInfo { get; set; }

    }
}
