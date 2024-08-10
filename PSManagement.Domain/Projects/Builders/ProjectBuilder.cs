using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Projects.DomainEvents;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.ValueObjects;
using PSManagement.Domain.ProjectsStatus.Entites;
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
        private ProjectStatus _projectStatus;
        private FinancialFund _financialFund;
        private Aggreement _projectAggreement;

        // information about who lead and execute the project 
        private int _teamLeaderId;
        private int _projectManagerId;
        private int _executerId;
        private int _proposerId;

        private ICollection<Step> _steps;
        private ICollection<Employee> _participants;
        private ICollection<Attachment> _attachments;

        public ICollection<FinancialSpending> FinancialSpending { get; set; }

        public ProjectBuilder WithProposalInfo(ProposalInfo proposalInfo)
        {
            _proposalInfo = proposalInfo;
            return this;
        }

        public ProjectBuilder WithProjectInfo(ProjectInfo projectInfo)
        {
            _projectInfo = projectInfo;
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
            foreach (Attachment attachment in attachments) {
                _attachments.Add(attachment);
            }
            return this;
        }

        public Project Build()
        {
            Project project= new Project(_proposalInfo, _projectInfo,_projectAggreement,_proposerId,_teamLeaderId,_projectManagerId ,_executerId);
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

            return project;
        }
    }

}
