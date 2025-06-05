using System.Threading;
using System.Threading.Tasks;

namespace Sam.Mediator
{
    public interface IMediator
    {
        Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default) where TRequest : IRequest<TResponse>;
    }

}
