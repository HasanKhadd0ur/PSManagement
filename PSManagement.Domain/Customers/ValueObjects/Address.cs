using PSManagement.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Customers.ValueObjects
{
    public class Address :ValueObject
    {
        public int StreetNumber { get; private set; }

        public int ZipCode { get; private set; }

        public String StreetName { get; private set; }

        public String City { get; private set; }
        public Address()
        {

        }
        public Address(string city, string streetName, int zipCode, int streetNumber)
        {
            City = city;
            StreetName = streetName;
            ZipCode = zipCode;
            StreetNumber = streetNumber;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StreetName;
            yield return StreetNumber;
            yield return City;
            yield return ZipCode;

        }
    }
}
