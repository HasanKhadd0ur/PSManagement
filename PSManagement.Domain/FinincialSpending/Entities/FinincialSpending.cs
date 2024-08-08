using PSManagement.SharedKernel.Entities;
using PSManagement.SharedKernel.ValueObjects;
using System;

namespace PSManagement.Domain.Projects.Entities
{
    public class FinincialSpending: BaseEntity
    {
        public String CostType { get; set; }
        public String Description { get; set; }
        public Money LocalPurchase { get; set; }
        public Money ExternalPurchase { get; set; }



    }
}
