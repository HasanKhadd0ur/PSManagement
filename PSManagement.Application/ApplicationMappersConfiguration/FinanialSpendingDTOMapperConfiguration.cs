using AutoMapper;
using PSManagement.Application.FinancialSpends.Common;
using PSManagement.Application.FinancialSpends.UseCases.Commands.CreateFinancialSpendItem;
using PSManagement.Domain.FinancialSpends.Entities;
using PSManagement.Application.FinancialSpends.UseCases.Commands.UpateFinancialSpendingItem;

namespace PSManagement.Application.Mappers
{
    public class FinanialSpendingDTOMapperConfiguration : Profile {


        public FinanialSpendingDTOMapperConfiguration()
        {
            CreateMap<FinancialSpendingDTO, FinancialSpending>().ReverseMap();



            CreateMap<CreateFinancialSpendItemCommand, FinancialSpending>()
                .ForMember(d => d.Id, op => op.Ignore())
                .ForMember(d => d.Events, op => op.Ignore())
                .ConstructUsing(src => new FinancialSpending(
                    src.ProjectId,
                    src.LocalPurchase,
                    src.ExternalPurchase,
                    src.CostType,
                    src.Description,
                    src.ExpectedSpendingDate
                ))
                ;


            CreateMap<UpdateFinancialSpendItemCommand, FinancialSpending>()
                ;

        }
    }

}
