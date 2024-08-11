﻿using Ardalis.Result;
using FluentValidation;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Behaviors.ValidationBehavior
{

    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> 
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators = null)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        { 
            if (_validators is null) {

                return await next();
            }

            var validationTasks = _validators.Select(v => v.ValidateAsync(request, cancellationToken));
            var validationResults = await Task.WhenAll(validationTasks);

            var errors = validationResults.SelectMany(r => r.Errors)
                                            .Where(e => e != null)
                                            .Select(e => new ValidationError(e.ErrorCode,e.ErrorMessage,e.ErrorCode,new ValidationSeverity()))
                                            .ToList();

            if (errors.Any())
            {
                return (dynamic)Result.Invalid(errors);
            }


            return await next();
        }
        private Result ValidateAsync(TRequest request)
        {
            var context = new ValidationContext<TRequest>(request);

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();
            if (failures.Count != 0)
            {

                var result = Result.Invalid(new ValidationError("validation Error."));
                //foreach (var failure in failures)
                //{
                //    result.Reasons.Add(new Error(failure.ErrorMessage));
                //}
                return  result;
                
            }

            return Result.Success();
        }
    }
}
