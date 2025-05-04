using Microsoft.Extensions.DependencyInjection;
using System;
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
        public async Task<TResponse> SendAsync<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest<TResponse>
        {

            var handler = serviceProvider.GetService<IRequestHandler<TRequest, TResponse>>();

            if (handler == null)
                throw new InvalidOperationException($"Handler not found for request type {request.GetType()}");

            return await handler.HandleAsync(request, cancellationToken);

        }
    }
}
