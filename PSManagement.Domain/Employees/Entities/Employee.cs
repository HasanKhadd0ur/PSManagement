using PSManagement.Domain.Identity.Entities;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.Entities;
using PSManagement.SharedKernel.Aggregate;
using PSManagement.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Employees.Entities
{
    public class Employee : BaseEntity
    {
        public int HIASTId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public WorkInfo WorkInfo { get; set; }

        public ICollection<Project> Projects { get; set; }
        
        public ICollection<EmployeeTrack> EmployeeTracks { get; set; }
        public Availability Availability { get; set; }

        public ICollection<EmployeeParticipate> EmployeeParticipates { get; set; }
        public Employee()
        {

        }
        public Employee(Availability availability, PersonalInfo personalInfo, int hiastId)
        {
            Availability = availability;
            PersonalInfo = personalInfo;
            HIASTId = hiastId;
        }
    }
    public record WorkInfo (
        String WorkType , 
        String WorkJob 
        );
}
