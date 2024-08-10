using PSManagement.Domain.Customers.Aggregate;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Projects.ValueObjects;
using PSManagement.Domain.ProjectsStatus.Entites;
using PSManagement.Domain.ProjectTypes.Entities;
using PSManagement.Domain.Tracking;
using PSManagement.SharedKernel.Aggregate;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Projects.Entities
{
    public class Project : IAggregateRoot
    {
        // information about the project itself 
        public ProposalInfo ProposalInfo { get; set; }
        public ProjectInfo ProjectInfo { get; set; }
        public ProjectStatus ProjectStatus { get; set; }
        public Aggreement ProjectAggreement { get; set; }

        // information about who lead and execute the project 
        public int TeamLeaderId { get; set; }
        public Employee TeamLeader { get; set; }
        public int ProjectManagerId { get; set; }
        public Employee ProjectManager { get; set; }
        public int ExecuterId { get; set; }
        public Department Executer { get; set; }

        // the proposer of the project 
        public int ProposerId { get; private set; }
        public Customer Proposer { get; set; }

        // 
        public ICollection<Step> Steps { get; set; }
        public ICollection<Employee> Participants { get; set; }
        public ICollection<Attachment> Attachments { get; set; }

        // finincial plan 
        public FinancialFund FinancialFund { get; set; }
        public ICollection<FinancialSpending> FinancialSpending { get; set; }



        public ICollection<EmployeeParticipate> EmployeeParticipates { get; set; }
        public ICollection<Track> Tracks { get; set; }

        public void AddAttachment(Attachment attachment) {

            Attachments.Add(attachment);

        }
        public void AddFinacialSpend(FinancialSpending financialSpending)
        {
            FinancialSpending.Add(financialSpending);

        }

        public void AddStep(Step step)
        {
            Steps.Add(step);

        }


        public Project(
            ProposalInfo proposalInfo,
            ProjectInfo projectInfo,
            Aggreement projectAggreement,
            int proposerId,
            int teamLeaderId,
            int projectManagerId,
            int executerId)
        {
            ProposalInfo = proposalInfo;
            ProjectInfo = projectInfo;
            ProjectAggreement = projectAggreement;
            TeamLeaderId = teamLeaderId;
            ProjectManagerId = projectManagerId;
            ExecuterId = executerId;
            ProposerId = proposerId;

            Attachments = new List<Attachment>();
            FinancialSpending = new List<FinancialSpending>();
            Steps = new List<Step>();
            Participants = new List<Employee>();
            EmployeeParticipates = new List<EmployeeParticipate>();

        }
        public Project()
        {

        }


    }
}
