using AutoMapper;
using PSManagement.Application.Contracts.Authentication;
using PSManagement.Application.Customers.Common;
using PSManagement.Application.Customers.UseCases.Commands.AddContactInfo;
using PSManagement.Application.Customers.UseCases.Commands.CreateCustomer;
using PSManagement.Application.Customers.UseCases.Commands.UpdateCustomer;
using PSManagement.Contracts.Authentication;
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
            CreateMap<CustomerDTO, CustomerResponse>();
            CreateMap<ContactInfoDTO, ContactInfoResponse>();

            CreateMap<CustomerResponse, CustomerDTO>().ReverseMap();
            
            CreateMap<IEnumerable<CustomerResponse>, ListCustomersResponse>()
                    .ConstructUsing(src => new ListCustomersResponse(src));

            CreateMap<AuthenticationResult,AuthenticationResponse>().ReverseMap();
        }
    }
}
