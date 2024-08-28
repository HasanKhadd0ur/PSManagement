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
            _trackSpecification.AddInclude(e => e.EmployeeTracks);
            _trackSpecification.AddInclude("EmployeeTracks.Employee");
            _trackSpecification.Criteria = e => e.ProjectId == request.ProjectId;

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


                var tracks = await _tracksRepository.ListAsync(_trackSpecification);

                // Dictionary to accumulate contributions by employee
                var contributionsByEmployee = new Dictionary<int, EmployeeContributionDTO>();

                foreach (Track track in tracks)
                {
                    foreach (EmployeeTrack employeeTrack in track.EmployeeTracks)
                    {
                        var employeeId = employeeTrack.Employee.Id; // Assuming Employee has an Id property
                        var contributionRatio = employeeTrack.EmployeeWork.ContributingRatio;

                        // If employee already has contributions, sum them up
                        if (contributionsByEmployee.ContainsKey(employeeId))
                        {
                            contributionsByEmployee[employeeId].ContributionRatio += contributionRatio;
                        }
                        else
                        {
                            // Otherwise, add a new entry for the employee
                            contributionsByEmployee[employeeId] = new EmployeeContributionDTO(contributionRatio, _mapper.Map<EmployeeDTO>(employeeTrack.Employee));
                        }
                    }
                }

                // Convert the dictionary values to a list for the final result
                var contributions = contributionsByEmployee.Values.ToList();


                //var tracks = await _tracksRepository.ListAsync(_trackSpecification);

                //var contributions = new List<EmployeeContributionDTO>();
                //foreach (Track track in tracks) {

                //    foreach (EmployeeTrack employeeTrack in track.EmployeeTracks) {
                //        // need to fix 
                //        contributions.Add(
                //         new  (employeeTrack.EmployeeWork.ContributingRatio,employeeTrack.Employee));
                //    }

                //}
                return Result.Success(contributions.AsEnumerable());


            }
        }
    }

}
