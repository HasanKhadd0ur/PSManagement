using Ardalis.Result;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSManagement.Api.Mappers
{
    public class MappersConfigurations :Profile
    {
        public MappersConfigurations()
        {
            CreateMap(typeof(Result<>), typeof(Result<>)).ConvertUsing(typeof(ResultToResultConverter<,>));
        }
    }
    public class ResultToResultConverter<TSource, TDestination> : ITypeConverter<Result<TSource>, Result<TDestination>>
    {
        public Result<TDestination> Convert(Result<TSource> source, Result<TDestination> destination, ResolutionContext context)
        {
            if (source.IsSuccess)
            {
                var mappedValue = context.Mapper.Map<TDestination>(source.Value);
                return Result.Success(mappedValue);
            }
            else
            {
                return Result.Invalid(source.ValidationErrors);
            }
        }
    }
}
