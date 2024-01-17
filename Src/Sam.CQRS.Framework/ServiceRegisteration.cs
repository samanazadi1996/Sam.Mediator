using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Sam.CQRS.Framework
{
    public static class ServiceRegisteration
    {
        public static IServiceCollection AddCQRS(this IServiceCollection services, Assembly assembly)
        {
            var commands = assembly.GetTypes().Where(type => type.GetInterface(typeof(IRequest<>).Name) != null);
            var commandHandlers = assembly.GetTypes().Where(type => type.GetInterface(typeof(IRequestHandler<,>).Name) != null);

            foreach (var commandType in commands)
            {
                var commandGenericType = commandType.GetInterface(typeof(IRequest<>).Name).GenericTypeArguments[0];
                var handler = commandHandlers.FirstOrDefault(type =>
                    type.GetInterface(typeof(IRequestHandler<,>).Name).GetGenericArguments()[0] == commandType);

                var handlerType = typeof(IRequestHandler<,>).MakeGenericType(commandType, commandGenericType);
                services.AddTransient(handlerType, handler);
            }

            services.AddScoped<ISender, Concrate.CQRSSender>();
            return services;
        }

    }
}
