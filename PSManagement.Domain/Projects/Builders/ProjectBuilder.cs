using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.FinancialSpends.Entities;
using PSManagement.Domain.Projects.DomainEvents;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Projects.Builders
{
    public class ProjectBuilder
    {
        private ProposalInfo _proposalInfo;
        private ProjectInfo _projectInfo;
        private FinancialFund _financialFund;
        private Aggreement _projectAggreement;

        // information about who lead and execute the project 
        private int _teamLeaderId;
        private int _projectManagerId;
        private int _executerId;
        private int _proposerId;
        private string _stateName;
        private ICollection<Step> _steps;
        private ICollection<EmployeeParticipate> _participants;
        private ICollection<Attachment> _attachments;

        private ICollection<FinancialSpending> _financialSpending;

        public ProjectBuilder WithParticipants(ICollection<EmployeeParticipate> participates)
        {
            _participants = participates;
            return this;
        }

            public ProjectBuilder WithFinancialSpending(ICollection<FinancialSpending> financialSpending)
        {
            _financialSpending = financialSpending;
            return this;
        }
        public ProjectBuilder WithSteps(ICollection<Step> steps)
        {
            _steps = steps;
            return this;
        }
        public ProjectBuilder WithProposalInfo(ProposalInfo proposalInfo)
        {
            _proposalInfo = proposalInfo;
            return this;
        }
        public ProjectBuilder WithTeamLeader(int  teamLeaderId)
        {
            _teamLeaderId = teamLeaderId;
            return this;
        }
        public ProjectBuilder WithProjectManager(int projectManagerId)
        {
            _projectManagerId = projectManagerId;
            return this;
        }
        public ProjectBuilder WithExecuter(int executerId)
        {
            _executerId = executerId;
            return this;
        }
        public ProjectBuilder WithProjectInfo(ProjectInfo projectInfo)
        {
            _projectInfo = projectInfo;
            return this;
        }
        public ProjectBuilder WithProposer(int proposerId)
        {
            _proposerId = proposerId;
            return this;
        }

        public ProjectBuilder WithFinancialFund(FinancialFund financialFund)
        {
            _financialFund = financialFund;
            return this;
        }
        public ProjectBuilder WithProjectAggreement(Aggreement projectAggreement)
        {
            _projectAggreement = projectAggreement;
            return this;
        }
        public ProjectBuilder WithAttachment(Attachment[] attachments)
        {
            _attachments = new List<Attachment>();
            foreach (Attachment attachment in attachments) {
                _attachments.Add(attachment);
            }
            return this;
        }
        public ProjectBuilder WithState(string stateName)
        {
            _stateName = stateName;
            return this;
        }

        public Project Build()
        {
            if (_stateName is null || _stateName == "") {
                _stateName = "Proposed";
            }
            Project project= new (
                _proposalInfo,
                _projectInfo,
                _projectAggreement,
                _proposerId,
                _teamLeaderId,
                _projectManagerId ,
                _executerId,
                _stateName);
            project.FinancialFund = _financialFund;

            if (_attachments is not null) {

                foreach (Attachment attachment in _attachments) {
                    project.AddAttachment(attachment);

                }
            }

            if (_steps is not null)
            {

                foreach (Step step in _steps)
                {
                    project.AddStep(step);

                }
            }
            if (_participants is not null)
            {

                foreach (EmployeeParticipate participate in _participants)
                {
                    project.EmployeeParticipates.Add(participate);

                }
            }
            return project;
        }
    }

}
