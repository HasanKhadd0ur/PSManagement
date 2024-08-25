using PSManagement.Domain.Projects.Entities;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSManagement.Domain.Projects.Repositories
{
    public interface IProjectTypesRepository : IRepository<ProjectType>
    {
        public Task<IEnumerable<Project>> GetProjectsByTypeName(string typeName, ISpecification<ProjectType> specification=null);
        public Task<IEnumerable<ProjectType>> GetByTypeName(string typeName, ISpecification<ProjectType> specification=null);
        
    }

}
