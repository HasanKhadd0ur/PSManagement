using Microsoft.EntityFrameworkCore;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Projects.Repositories;
using PSManagement.Infrastructure.Persistence.Repositories.Base;
using PSManagement.SharedKernel.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSManagement.Infrastructure.Persistence.Repositories.ProjectRepository
{
    public class ProjectsTypesRepository : BaseRepository<ProjectType>, IProjectTypesRepository
    {
        public ProjectsTypesRepository(AppDbContext context) : base(context)
        {
        }

        public async  Task<IEnumerable<ProjectType>> GetByTypeName(string typeName, ISpecification<ProjectType> specification = null)
        {
            IQueryable<ProjectType> query = ApplySpecification(specification);
            return await query.Where(e => e.TypeName == typeName).ToListAsync();

        }

    }

}
