using PSManagement.Domain.Employees.Aggregate;
using PSManagement.SharedKernel.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Departments.Aggregate
{
    public class Department :IAggregateRoot
    {
        public String Name { get; set; }
        public Department(string name)
        {
            Name = name;
        }
        public Department()
        {

        }
    }
}
