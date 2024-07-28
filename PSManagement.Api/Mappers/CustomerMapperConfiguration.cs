using AutoMapper;
using PSManagement.Application.Customers.Common;
using PSManagement.Application.Customers.UseCases.Commands.AddContactInfo;
using PSManagement.Application.Customers.UseCases.Commands.CreateCustomer;
using PSManagement.Application.Customers.UseCases.Commands.UpdateCustomer;
using PSManagement.Contracts.Customers.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSManagement.Api.Mappers
{
    public class CustomerMapperConfiguration : Profile
    {
        public CustomerMapperConfiguration()
        {
            CreateMap<CreateCustomerRequest, CreateCustomerCommand>().ReverseMap();
            CreateMap<UpdateCustomerCommand, UpdateCustomerRequest>().ReverseMap();

            CreateMap<AddContactInfoRequest, AddContactInfoCommand>().ReverseMap();
            CreateMap<AddressRecord, AddressDTO>().ReverseMap();

        }
    }
}
