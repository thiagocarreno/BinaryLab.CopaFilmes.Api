using BinaryLab.CopaFilmes.Api;
using Microsoft.Extensions.DependencyInjection;

namespace BinaryLab.CopaFilmes.Hospedagem.InjecaoDependencia
{
    public static class Extensoes
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            return AddApiServices(services, string.Empty);
        }

        public static IServiceCollection AddApiServices(this IServiceCollection services, string swaggerTitle)
        {
            services.AddApi()
                .AddVersionamentoApi()
                .AddSwagger(swaggerTitle);

            return services;
        }
    }
}
