using BinaryLab.CopaFilmes.Filme.Repositorio.Abstracoes;
using Microsoft.Extensions.DependencyInjection;

namespace BinaryLab.CopaFilmes.Filme.Repositorio.InjecaoDependencia
{
    public static class Extensoes
    {
        public static IServiceCollection AddFilmeRepositorio(this IServiceCollection services)
        {
            services.AddScoped(typeof(IFilmeRepositorio), typeof(FilmeRepositorio));
            return services;
        }
    }
}
