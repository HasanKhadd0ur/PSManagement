﻿using PSManagement.Domain.Employees.Entities;
using PSManagement.SharedKernel.Entities;
using System;

namespace PSManagement.Domain.Projects.Entities
{
    public class EmployeeParticipate : BaseEntity
    {
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public Employee Employee { get; set; }
        public Project Project { get; set; }
        public int PartialTimeRatio { get; set; }
        public string Role { get; set; }
    }
}