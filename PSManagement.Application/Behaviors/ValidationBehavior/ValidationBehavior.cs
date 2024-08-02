using FluentResults;
using FluentValidation;
using MediatR;
using PSManagement.Application.Common.Exceptions;
using PSManagement.SharedKernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = PSManagement.Application.Common.Exceptions.ValidationException;

namespace PSManagement.Application.Behaviors.ValidationBehavior
{

    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> where TResponse  : ResultBase  
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators = null)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            if (_validators is null) {

                return await next();
            }
            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
            {
                var result =Result.Fail("validation Error.");
                foreach (var failure in failures)
                {
                    result.Reasons.Add(new Error(failure.ErrorMessage));
                }
                return (dynamic)result;
            }

            return await next();
        }
    }
}
