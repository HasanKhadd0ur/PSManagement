﻿using PSManagement.Domain.Employees.Entities;

namespace PSManagement.Contracts.Projects.Response
{
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public int HIASTId { get; set; }
        public int UserId { get; set; }
        public string DepartmentName { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public WorkInfo WorkInfo { get; set; }
    }
}