using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Customers.Common
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public String CustomerName { get; set; }
        public AddressDTO Address { get; set; }
        public String Email { get; set; }
        public IEnumerable<ContactInfoDTO> ContactInfo { get; private set; }

    }
}
