using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Tracking;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Projects.Repositories
{
    public interface IProjectsRepository :IRepository<Project>
    {
        public IEnumerable<EmployeeParticipate> GetProjectParticipants(int projectId, ISpecification<Project> specification=null);
        public IEnumerable<Step> GetProjectPlan(int projectId);
        public IEnumerable<Track> GetProjectTracks(int projectId);
        
    }

}
