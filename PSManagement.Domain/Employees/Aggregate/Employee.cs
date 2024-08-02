using PSManagement.SharedKernel.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Employees.Aggregate
{
    public class Employee :IAggregateRoot
    {
        public int HIASTId{ get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public Availability Availability { get; set; }

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
    
    public record PersonalInfo(
        String FirstName ,
        String LastName
        );

    public record Availability (
        int WorkingHours ,
        Boolean IsAvailable
        );

}
