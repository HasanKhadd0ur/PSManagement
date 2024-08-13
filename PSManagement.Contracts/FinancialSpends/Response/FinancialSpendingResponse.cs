using PSManagement.SharedKernel.ValueObjects;
using System;

namespace PSManagement.Contracts.Projects.Response
{
    public class FinancialSpendingResponse
    {
        public int Id { get; set; }
        public DateTime ExpectedSpendingDate { get; set; }
        public String CostType { get; set; }
        public String Description { get; set; }
        public int LocalPurchase { get; set; }
        public Money ExternalPurchase { get; set; }
    }
}