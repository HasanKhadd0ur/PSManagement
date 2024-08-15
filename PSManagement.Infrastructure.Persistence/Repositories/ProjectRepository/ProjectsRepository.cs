using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.Domain.Tracking;
using PSManagement.Infrastructure.Persistence.Repositories.Base;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Infrastructure.Persistence.Repositories.ProjectRepository
{
    public class ProjectsRepository : BaseRepository<Project> , IProjectsRepository
    {
        public ProjectsRepository(AppDbContext context) : base(context)
        {
        }

      
        public IEnumerable<EmployeeParticipate> GetProjectParticipants(int projectId, ISpecification<Project> specification)
        {

            return  ApplySpecification(specification).Where(p =>p.Id== projectId).FirstOrDefault().EmployeeParticipates.AsEnumerable();

        }

        public IEnumerable<Step> GetProjectPlan(int projectId)
        {
            return _dbContext.Projects.Where(p => p.Id == projectId).FirstOrDefault()?.Steps.AsEnumerable();

        }

        public IEnumerable<Track> GetProjectTracks(int projectId)
        {
            return _dbContext.Projects.Where(p => p.Id == projectId).FirstOrDefault()?.Tracks.AsEnumerable();

        }
    }
}
