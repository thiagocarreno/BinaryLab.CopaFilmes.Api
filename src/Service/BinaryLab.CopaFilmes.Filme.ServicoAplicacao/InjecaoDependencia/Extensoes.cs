using AutoMapper;
using BinaryLab.CopaFilmes.Filme.ServicoAplicacao.Abstracoes;
using BinaryLab.CopaFilmes.Filme.ServicoAplicacao.Mapeamentos;
using Microsoft.Extensions.DependencyInjection;

namespace BinaryLab.CopaFilmes.Filme.ServicoAplicacao.InjecaoDependencia
{
    public static class Extensoes
    {
        public static IServiceCollection AddFilmeServicoAplicacao(this IServiceCollection services)
        {
            services.AddScoped(typeof(IFilmeServicoAplicacao), typeof(FilmeServicoAplicacao));
            return services;
        }

        public static IServiceCollection AddMapeamentosFilmeServicoAplicacao(this IServiceCollection services)
        {
            services.AddScoped(typeof(IMapper), c =>
                new MapperConfiguration(cfg =>
                    cfg.AddProfile<FilmeMapper>()
                ).CreateMapper()
            );

            return services;
        }
    }
}
