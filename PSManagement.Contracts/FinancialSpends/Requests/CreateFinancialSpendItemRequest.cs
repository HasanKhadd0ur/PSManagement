using PSManagement.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Contracts.FinancialSpends.Requests
{
    public record CreateFinancialSpendItemRequest(
    int ProjectId,
    Money ExternalPurchase,
    int LocalPurchase,
    string CostType,
    string Description,
    DateTime ExpectedSpendingDate
    );
}
