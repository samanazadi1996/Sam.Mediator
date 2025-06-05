using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sam.Mediator.Concrate
{
    public class Mediator : IMediator
    {
        private readonly IServiceProvider serviceProvider;

        public Mediator(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public async Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest<TResponse>
        {

            var handler = serviceProvider.GetService<IRequestHandler<TRequest, TResponse>>();

            if (handler == null)
                throw new InvalidOperationException($"Handler not found for request type {request.GetType()}");

            var behaviors = serviceProvider.GetServices<IPipelineBehavior<TRequest, TResponse>>().Reverse();
            Func<Task<TResponse>> handlerDelegate = () => handler.Handle(request, cancellationToken);
            foreach (var behavior in behaviors)
            {
                var next = handlerDelegate;
                handlerDelegate = () => behavior.Handle(request, next, cancellationToken);
            }

            return await handlerDelegate();

        }
    }
}
