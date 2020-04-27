using BinaryLab.CopaFilmes.Repositorio.Abstracoes;
using Microsoft.Extensions.DependencyInjection;

namespace BinaryLab.CopaFilmes.Repositorio.Http.InjecaoDependencia
{
    public static class Extensoes
    {
        public static IServiceCollection AddRepositorioHttp(this IServiceCollection services)
        {
            services.AddRepositorioHttpLeitura();

            return services;
        }

        public static IServiceCollection AddRepositorioHttpLeitura(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IRepositorioLeitura<>), typeof(RepositorioHttpLeitura<>));
            services.AddSingleton(typeof(IRepositorioLeitura<,>), typeof(RepositorioHttpLeitura<,>));

            return services;
        }
    }
}
