using BinaryLab.CopaFilmes.Validacao.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace BinaryLab.CopaFilmes.Validacao
{
    public static class Extensions
    {
        public static IServiceCollection AddNotifications(this IServiceCollection services)
        {
            services.AddTransient<INotificationContext, NotificationContext>();

            return services;
        }
    }
}
