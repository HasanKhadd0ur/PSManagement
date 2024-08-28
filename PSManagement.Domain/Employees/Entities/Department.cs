using PSManagement.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Employees.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }

        #region Constructors
        public Department(string name)
        {
            Name = name;
        }
        public Department()
        {

        }
        #endregion Constructors
    }
}
