using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.SharedKernel.ValueObjects
{
    public record Money(
        int Ammount , 
        String Currency 
        );
}
