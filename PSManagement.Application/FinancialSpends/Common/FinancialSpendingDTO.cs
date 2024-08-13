using PSManagement.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.FinancialSpends.Common
{
    public class FinancialSpendingDTO
    {
        public int Id { get; set; }
        public DateTime ExpectedSpendingDate { get; set; }
        public string CostType { get; set; }
        public string Description { get; set; }
        public int LocalPurchase { get; set; }
        public Money ExternalPurchase { get; set; }
    }
}
