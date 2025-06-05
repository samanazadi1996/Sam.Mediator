using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sam.Mediator
{
    public interface IPipelineBehavior<in TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request, Func<Task<TResponse>> next, CancellationToken cancellationToken = default);
    }
}
