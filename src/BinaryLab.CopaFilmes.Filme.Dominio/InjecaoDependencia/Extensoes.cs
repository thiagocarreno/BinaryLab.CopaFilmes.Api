using BinaryLab.CopaFilmes.Filme.Dominio.Abstracoes;
using Microsoft.Extensions.DependencyInjection;

namespace BinaryLab.CopaFilmes.Filme.Dominio.InjecaoDependencia
{
    public static class Extensoes
    {
        public static IServiceCollection AddFilmeDominio(this IServiceCollection services)
        {
            services.AddScoped(typeof(IFilmeDominio), typeof(FilmeDominio));
            return services;
        }
    }
}
