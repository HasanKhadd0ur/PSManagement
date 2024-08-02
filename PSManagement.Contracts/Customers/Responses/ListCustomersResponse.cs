using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Contracts.Customers.Responses
{
    public record  ListCustomersResponse( IEnumerable<CustomerRecord> Customers );
    
}
