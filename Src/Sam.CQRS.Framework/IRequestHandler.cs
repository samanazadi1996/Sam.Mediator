using System.Threading.Tasks;

namespace Sam.CQRS.Framework
{
    public interface IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        Task<TResponse> Handler(TRequest request);
    }
}
