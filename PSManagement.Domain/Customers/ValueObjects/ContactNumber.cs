using PSManagement.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Customers.ValueObjects
{
    public sealed class ContactNumber : ValueObject
    {
        public int Number { get; private set; }
        public ContactNumber(int number)
        {
            SetNumber(number);
        }
        public ContactNumber()
        {

        }

        private void SetNumber(int number)
        {
            Number = number;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
        }
    }
}
