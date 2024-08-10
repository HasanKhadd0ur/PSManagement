using PSManagement.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Customers.ValueObjects
{
    public record Address(
         int StreetNumber ,
         int ZipCode ,
         String StreetName ,
         String City );
}
