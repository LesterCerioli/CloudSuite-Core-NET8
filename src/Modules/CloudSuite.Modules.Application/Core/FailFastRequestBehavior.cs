using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace CloudSuite.Modules.Application.Core
{
    public class FailFastRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> where TResponse : Response
    {
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}