using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.Employees.Common;
using PSManagement.Application.Projects.Common;
using PSManagement.Domain.Projects;
using PSManagement.Domain.Projects.DomainErrors;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.Domain.Steps.Repositories;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.Specification;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Specification;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Projects.UseCases.Queries.GetCompletionContribution
{
    public class GetCompletionContributionQueryHandler : IQueryHandler<GetCompletionContributionQuery, Result<IEnumerable<EmployeeContributionDTO>>>
    {
        private readonly IProjectsRepository _projectsRepository;
        
        private readonly BaseSpecification<Project> _projectSpecification;
        private readonly BaseSpecification<Track> _trackSpecification;
        private readonly ITracksRepository  _tracksRepository;
        private readonly IMapper _mapper;
        public GetCompletionContributionQueryHandler(
            IProjectsRepository projectsRepository,
            ITracksRepository tracksRepository,
            IMapper mapper )
        {
            _projectSpecification = new ProjectSpecification();
            _trackSpecification = new TrackSpecification();
            _projectsRepository = projectsRepository;

            _tracksRepository = tracksRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<EmployeeContributionDTO>>> Handle(GetCompletionContributionQuery request, CancellationToken cancellationToken)
        {
            _projectSpecification.AddInclude(e=> e.Tracks);
            _projectSpecification.AddInclude("Tracks.EmployeeTracks.Employee");
            _projectSpecification.AddInclude(e=>e.ProjectCompletion);

            Project project = await _projectsRepository.GetByIdAsync(request.ProjectId, _projectSpecification);
           
            if (project is null)
            {
                return Result.Invalid(ProjectsErrors.InvalidEntryError);
            }
            else
            {
                if (project.ProjectCompletion is null)
                {

                    return Result.Invalid(ProjectsErrors.UnCompletedError);
                }

                IEnumerable<ParticipantContribution> contributions = project.CalculateContributions();
           
                return Result.Success(_mapper.Map<IEnumerable<EmployeeContributionDTO>>(contributions));


            }
        }
    }

}
