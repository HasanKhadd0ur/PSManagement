using PSManagement.Application.Employees.Common;
using PSManagement.Application.FinancialSpends.Common;
using PSManagement.Domain.Customers.Entities;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.ValueObjects;
using PSManagement.Domain.ProjectsStatus.Entites;
using System;
using System.Collections.Generic;

namespace PSManagement.Application.Projects.Common
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public ProposalInfo ProposalInfo { get; set; }
        public ProjectInfo ProjectInfo { get; set; }
        public string CurrentState { get; set; }
        public Aggreement ProjectAggreement { get; set; }
        public int TeamLeaderId { get; set; }

        public EmployeeDTO TeamLeader { get; set; }
        public int ProjectManagerId { get; set; }
        public EmployeeDTO ProjectManager { get; set; }
        public int ExecuterId { get; set; }
        public Department Executer { get; set; }

        public int ProposerId { get; private set; }
        public Customer Proposer { get; set; }
        public ICollection<StepDTO> Steps { get; set; }
        public ICollection<Attachment> Attachments { get; set; }

        public FinancialFund FinancialFund { get; set; }
        public ICollection<FinancialSpendingDTO> FinancialSpending { get; set; }

        public ICollection<EmployeeParticipateDTO> EmployeeParticipates { get; set; }

        public ProjectDTO()
        {

        }
    }
}