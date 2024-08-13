using PSManagement.SharedKernel.Entities;
using PSManagement.SharedKernel.ValueObjects;
using System;

namespace PSManagement.Domain.FinancialSpends.Entities
{
    public class FinancialSpending : BaseEntity
    {
        public DateTime ExpectedSpendingDate { get; set; }
        public string CostType { get; set; }
        public string Description { get; set; }
        public int LocalPurchase { get; set; }
        public Money ExternalPurchase { get; set; }



    }
}
