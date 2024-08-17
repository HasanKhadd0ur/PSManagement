using PSManagement.Domain.Customers.Entities;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.FinancialSpends.Entities;
using PSManagement.Domain.Projects.ValueObjects;
using PSManagement.Domain.Tracking;
using PSManagement.SharedKernel.Aggregate;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
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
        public Aggreement ProjectAggreement { get; set; }

        // state management 
        public string CurrentState { get; private set; }  // Persisted in the database

        [NotMapped]
        private IProjectState _state ;
        [NotMapped]
        public IProjectState State {
            get {

                if (_state is null) {
                    SetStateFromString(CurrentState);
                }

                return _state;
            }
            
            set => _state = value;
        }

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
            int executerId,
            string stateName)
        {
            SetStateFromString(stateName);
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
        public void SetState(IProjectState newState)
        {
            _state = newState;
            CurrentState = _state.StateName; 
        }
        public void Complete() 
        {
            State.Complete(this);
        
        }
        public void Plan()
        {
            State.Plan(this);

        }
        public void Approve(Aggreement projectAggreement)
        {
            State.Approve(this,projectAggreement);

        }
        public void Cancel(DateTime canellationTime)
        {
            State.Cancel(this,canellationTime);

        }
        public void Propose()
        {
            State.Propose(this);

        }

        public void SetStateFromString(string stateName)
        {
            switch (stateName)
            {
                case "Proposed":
                    SetState(new ProposedState());
                    break;
                case "InPlan":
                    SetState(new InPlanState());
                    break;
                case "Cancled":
                    SetState(new CancledState());
                    break;
                case "InProgress":
                    SetState(new InProgressState());
                    break;
                case "Completed":
                    SetState(new CompletedState());
                    break;
                default:
                    throw new InvalidOperationException("Unknown state");
            }
        }

    }

}
