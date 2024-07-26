using PSManagement.Domain.Customers.Aggregate;
using PSManagement.SharedKernel.Repositories;


namespace PSManagement.Domain.Customers.Repositories
{
    public interface ICustomersRepository :IRepository<Customer>
    {

    }
}
