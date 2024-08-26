using System;

namespace PSManagement.Application.Projects.Common
{
    public class ParticipationChangeDTO
    {

        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public int PartialTimeBefore { get; set; }
        public int PartialTimeAfter { get; set; }
        public string RoleBefore { get; set; }
        public string RoleAfter { get; set; }
        public DateTime ChangeDate { get; set; }


    }

}