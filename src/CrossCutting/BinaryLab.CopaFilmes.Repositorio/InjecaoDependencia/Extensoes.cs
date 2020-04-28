using BinaryLab.CopaFilmes.Repositorio.Abstracoes;
using Microsoft.Extensions.DependencyInjection;

namespace BinaryLab.CopaFilmes.Repositorio.InjecaoDependencia
{
    public static class Extensoes
    {
        public static IServiceCollection AddRepositorio(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IRepositorio<>), typeof(Repositorio<>));
            return services;
        }
    }
}
