using PSManagement.Domain.ProjectTypes.Entities;
using PSManagement.SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.ProjectTypes.Repositories
{
    public interface IProjectTypesRepository : IRepository<ProjectType>
    {
    }
}
