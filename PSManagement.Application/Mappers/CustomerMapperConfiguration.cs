using AutoMapper;
using PSManagement.Application.Customers.Common;
using PSManagement.Domain.Customers.Aggregate;
using PSManagement.Domain.Customers.Entities;
using PSManagement.Domain.Customers.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Mappers
{
    class CustomerMapperConfiguration :Profile
    {
        public CustomerMapperConfiguration()
        {
            CreateMap<CustomerDTO, Customer>().ReverseMap();
            CreateMap<ContactInfoDTO, ContactInfo>().ReverseMap();

        }
    }
}
