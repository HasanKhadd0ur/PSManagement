using PSManagement.Domain.Identity.Entities;
using PSManagement.SharedKernel.Interfaces;
using PSManagement.SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Identity.Repositories
{
    public interface IUsersRepository : IRepository<User>
    {
        public Task<User> GetByEmail(string email, ISpecification<User> specification = null);
    }
}
