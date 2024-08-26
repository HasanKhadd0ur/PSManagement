using PSManagement.Domain.Employees.Entities;
using PSManagement.SharedKernel.Entities;
using System;

namespace PSManagement.Domain.Projects.Entities
{
    public class ParticipationChange :BaseEntity{

        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public int PartialTimeBefore { get; set; }
        public int PartialTimeAfter { get; set; }
        public string RoleBefore { get; set; }
        public string RoleAfter { get; set; }
        public DateTime ChangeDate { get; set; }
        public Employee Employee { get; set; }
        public Project Project { get; set; }


    }
}
