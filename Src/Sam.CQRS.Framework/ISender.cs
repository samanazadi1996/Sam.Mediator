using System.Threading.Tasks;

namespace Sam.CQRS.Framework
{
    public interface ISender
    {
        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }

}
