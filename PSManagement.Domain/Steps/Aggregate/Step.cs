using PSManagement.Domain.Steps.Entities;
using PSManagement.SharedKernel.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Steps.Aggregate
{
    public class Step :IAggregateRoot
    {
        public String StepName { get; set; }
        public String Description { get; set; }
        public int Duration { get; set; }
        public DateTime StartDate { get; set; }

        public ICollection<Item> Purchases { get; set; }

        public Step()
        {

        }
    }

}
