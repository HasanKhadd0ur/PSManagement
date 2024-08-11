using AutoMapper;
using PSManagement.Application.Customers.Common;
using PSManagement.Application.Customers.UseCases.Commands.AddContactInfo;
using PSManagement.Application.Customers.UseCases.Commands.CreateCustomer;
using PSManagement.Application.Customers.UseCases.Commands.UpdateCustomer;
using PSManagement.Contracts.Customers.Requests;
using PSManagement.Contracts.Customers.Responses;
using PSManagement.SharedKernel.Utilities;
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
            CreateMap<CustomerDTO, CustomerRecord>();
            CreateMap<ContactInfoDTO, ContactInfoRecord>();

            CreateMap<CustomerRecord, CustomerDTO>().ReverseMap();
            
            CreateMap<IEnumerable<CustomerRecord>, ListCustomersResponse>()
                    .ConstructUsing(src => new ListCustomersResponse(src));
            
        }
    }
}
