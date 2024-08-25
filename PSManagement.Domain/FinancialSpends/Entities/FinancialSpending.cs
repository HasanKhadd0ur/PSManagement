using PSManagement.SharedKernel.Entities;
using PSManagement.SharedKernel.ValueObjects;
using System;

namespace PSManagement.Domain.FinancialSpends.Entities
{
    public class FinancialSpending : BaseEntity
    {
        public int ProjectId { get; set; }
        public DateTime ExpectedSpendingDate { get; set; }
        public string CostType { get; set; }
        public string Description { get; set; }
        public int LocalPurchase { get; set; }
        public Money ExternalPurchase { get; set; }

        #region  Constructors
        public FinancialSpending()
        {

        }

        public FinancialSpending(
            int projectId,
            int localPurchase,
            Money externalPurchase,
            string costType,
            string description,
            DateTime expectedSpendingDate)
        {
            ProjectId = projectId;
            LocalPurchase = localPurchase;
            ExternalPurchase = externalPurchase;
            CostType = costType;
            Description = description;
            ExpectedSpendingDate = expectedSpendingDate;
        }
        #endregion  Constructors


    }
}
