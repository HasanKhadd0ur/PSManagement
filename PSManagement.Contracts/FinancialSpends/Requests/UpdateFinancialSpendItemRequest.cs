using PSManagement.SharedKernel.ValueObjects;
using System;

namespace PSManagement.Contracts.FinancialSpends.Requests
{
    public record UpdateFinancialSpendItemRequest(
        int ProjectId,
        int Id,
        Money ExternalPurchase,
        int LocalPurchase,
        string CostType,
        string Description,
        DateTime ExpectedSpendingDate
        );
}
