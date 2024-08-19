using Ardalis.Result;
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
        #region Project  informations
        
        public ProposalInfo ProposalInfo { get; set; }
        public ProjectInfo ProjectInfo { get; set; }
        public Aggreement ProjectAggreement { get; set; }

        #endregion Project  informations

        #region Project State 
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

        #endregion Project State

        // information about who lead and execute the project 
        #region Project Management Iformations 

        public int TeamLeaderId { get; set; }
        public Employee TeamLeader { get; set; }
        public int ProjectManagerId { get; set; }
        public Employee ProjectManager { get; set; }
        public int ExecuterId { get; set; }
        public Department Executer { get; set; }
        public FinancialFund FinancialFund { get; set; }
        public ICollection<FinancialSpending> FinancialSpending { get; set; }

        #endregion Project Management Iformations 

        // the proposer of the project 
        public int ProposerId { get; private set; }
        public Customer Proposer { get; set; }

        // 
        public ICollection<Step> Steps { get; set; }
        public ICollection<Employee> Participants { get; set; }
        public ICollection<Attachment> Attachments { get; set; }


        public ICollection<EmployeeParticipate> EmployeeParticipates { get; set; }
        public ICollection<Track> Tracks { get; set; }



        #region Encapsulating the collection operations 
        public void AddAttachment(Attachment attachment)
        {

            Attachments.Add(attachment);

        }
        public void AddAttachment(string attachmentUrl,string attachmentName,string attachmentDescription,int projectId)
        {
            Attachment attachment = new(attachmentUrl, attachmentName,attachmentDescription, projectId);

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

        #endregion Encapsulating the collection operations 

        #region State Transitions

        public Result Complete() 
        {
            return State.Complete(this);
        
        }
        public Result Plan()
        {
            return State.Plan(this);

        }
        public Result Approve(Aggreement projectAggreement)
        {
            return State.Approve(this, projectAggreement);

        }
        public Result Cancel(DateTime canellationTime)
        {
            return State.Cancel(this,canellationTime);

        }
        public Result Propose()
        {
            return State.Propose(this);

        }

        #endregion State Transitions
        public Project(
            ProposalInfo proposalInfo,
            ProjectInfo projectInfo,
            Aggreement projectAggreement,
            int proposerId,
            int teamLeaderId,
            int projectManagerId,
            int executerId,
            string stateName
            )
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

        #region state extracting from state name 
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
        #endregion state extracting from state name 
    }

}
