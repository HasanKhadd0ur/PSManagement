using PSManagement.Application.Employees.Common;
using PSManagement.Domain.Customers.Entities;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Projects.ValueObjects;

namespace PSManagement.Application.Projects.Common
{
    public class ProjectDetailsDTO
    {
        public int Id { get; set; }
        public ProposalInfo ProposalInfo { get; set; }
        public ProjectInfo ProjectInfo { get; set; }
        public string CurrentState { get; set; }
        public Aggreement ProjectAggreement { get; set; }
        public ProjectClassification ProjectClassification { get; set; }
        public EmployeeDTO TeamLeader { get; set; }
        public EmployeeDTO ProjectManager { get; set; }
        public Department Executer { get; set; }
        public Customer Proposer { get; set; }
        public FinancialFund FinancialFund { get; set; }
        
        public ProjectDetailsDTO()
        {

        }
    }
}