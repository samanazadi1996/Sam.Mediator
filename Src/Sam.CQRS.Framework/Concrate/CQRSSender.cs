using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace Sam.CQRS.Framework.Concrate
{
    public class CQRSSender : ISender
    {
        private readonly IServiceProvider serviceProvider;

        public CQRSSender(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request)
        {
            Type handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            var service = serviceProvider.GetService(handlerType);

            if (service == null)
                throw new InvalidOperationException($"Handler not found for request type {request.GetType()}");


            var handleMethod = service.GetType().GetMethod("Handler");
            if (handleMethod == null)
                throw new InvalidOperationException($"Handle method not found for request type {request.GetType()}");

            return await (Task<TResponse>)handleMethod.Invoke(service, new object[] { request });
        }
    }
}
