using PSManagement.Domain.Customers.Aggregate;
using PSManagement.Domain.Customers.Repositories;
using PSManagement.Infrastructure.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Infrastructure.Persistence.Repositories.CustomerRepository
{
    public class CustomersReposiotry : BaseRepository<Customer> , ICustomersRepository
    {
        public CustomersReposiotry(AppDbContext context) : base(context)
        {
        }
    }
}
