using PSManagement.Domain.FinancialSpends.Entities;
using PSManagement.SharedKernel.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.FinancialSpends.Specification
{
    public class FinancialSpendingSpecification : BaseSpecification<FinancialSpending>
    {
        public FinancialSpendingSpecification(Expression<Func<FinancialSpending, bool>> criteria = null) : base(criteria)
        {

        }
    
    }
}
