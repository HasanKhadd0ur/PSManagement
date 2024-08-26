using PSManagement.Application.Projects.Common;
using PSManagement.Contracts.Customers.Responses;
using PSManagement.Contracts.ProjectsTypes.Request;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.ValueObjects;
using System;
using System.Collections.Generic;

namespace PSManagement.Contracts.Projects.Response
{
    public class ProjectResponse
    {
        public int Id { get; set; }
        public ProposalInfo ProposalInfo { get; set; }
        public ProjectInfo ProjectInfo { get; set; }
        public string CurrentState { get; set; }
        public ProjectTypeResponse ProjectType { get; set; }
        public Aggreement ProjectAggreement { get; set; }
        public int TeamLeaderId { get; set; }
        public int ProjectTypeId { get; set; }

        public ProjectClassification ProjectClassification { get; set; }
        public EmployeeResponse TeamLeader { get; set; }
        public int ProjectManagerId { get; set; }
        public EmployeeResponse ProjectManager { get; set; }
        public int ExecuterId { get; set; }
        public DepartmentResponse Executer { get; set; }

        public int ProposerId { get; private set; }
        public CustomerResponse Proposer { get; set; }
        public ICollection<StepResponse> Steps { get; set; }
        public ICollection<AttachmentReponse> Attachments { get; set; }

        public FinancialFund FinancialFund { get; set; }
        public ICollection<FinancialSpendingResponse> FinancialSpending { get; set; }

        public ICollection<EmployeeParticipateResponse> EmployeeParticipates { get; set; }

    }

    public class ParticipationChange
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
