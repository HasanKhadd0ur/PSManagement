using AutoMapper;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSManagement.Api.Mappers
{
    public class MapperConfigurations :Profile
    {
        public MapperConfigurations()
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
                return Result.Ok(mappedValue);
            }
            else
            {
                return Result.Fail<TDestination>(source.Errors);
            }
        }
    }
}
