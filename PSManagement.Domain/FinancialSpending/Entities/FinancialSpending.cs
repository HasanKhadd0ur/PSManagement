using PSManagement.SharedKernel.Entities;
using PSManagement.SharedKernel.ValueObjects;
using System;

namespace PSManagement.Domain.Projects.Entities
{
    public class FinancialSpending: BaseEntity
    {
        public DateTime ExpectedSpendingDate { get; set; }
        public String CostType { get; set; }
        public String Description { get; set; }
        public int LocalPurchase { get; set; }
        public Money ExternalPurchase { get; set; }



    }
}
