using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Customers.Common
{
    public record  AddressDTO(
        int StreetNumber,
        int ZipCode ,
        String StreetName ,
        String City );
}
