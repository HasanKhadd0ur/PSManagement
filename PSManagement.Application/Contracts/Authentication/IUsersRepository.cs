using PSManagement.SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Contracts.Authentication
{
    public interface IUsersRepository : IRepository<User>
    {
        public Task<User> GetByEmail(String email);
    }
}
