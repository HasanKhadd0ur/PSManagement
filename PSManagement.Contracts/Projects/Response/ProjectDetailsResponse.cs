using PSManagement.Contracts.Customers.Responses;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Projects.ValueObjects;

namespace PSManagement.Contracts.Projects.Response
{
    public class ProjectDetailsResponse
    {
        public int Id { get; set; }
        public ProposalInfo ProposalInfo { get; set; }
        public ProjectInfo ProjectInfo { get; set; }
        public string CurrentState { get; set; }
        public Aggreement ProjectAggreement { get; set; }
        
        public ProjectClassification ProjectClassification { get; set; }
        public EmployeeResponse TeamLeader { get; set; }
        public EmployeeResponse ProjectManager { get; set; }
        public Department Executer { get; set; }

        public CustomerResponse Proposer { get; set; }
        
        public FinancialFund FinancialFund { get; set; }
        
        
    }

}
