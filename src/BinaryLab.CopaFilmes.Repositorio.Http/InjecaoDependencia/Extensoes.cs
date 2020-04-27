using System;
using System.Net.Http;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes;
using BinaryLab.CopaFilmes.Repositorio.Http.Abstracoes;
using JetBrains.Annotations;
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

        public static IServiceCollection AddClienteHttp(this IServiceCollection services, [NotNull] string nomeCliente,
            [NotNull] string urlBase)
        {
            if (nomeCliente == null)
                throw new ArgumentNullException(nameof(nomeCliente));
            
            if (urlBase == null)
                throw new ArgumentNullException(nameof(urlBase));

            services.AddHttpClient(nomeCliente, c => c.BaseAddress = new Uri(urlBase));
            return services;
        }

        public static IServiceCollection AddContextoHttp(this IServiceCollection services, [NotNull] string nomeCliente,
            [NotNull] string urlRecursoApi)
        {
            if (nomeCliente == null)
                throw new ArgumentNullException(nameof(nomeCliente));
            
            if (urlRecursoApi == null)
                throw new ArgumentNullException(nameof(urlRecursoApi));

            services.AddSingleton(typeof(IHttpContexto), i =>
            {
                var httpClientFactory = i.GetRequiredService<IHttpClientFactory>();

                var instance = new ContextoHttp(httpClientFactory.CreateClient(nomeCliente), urlRecursoApi);
                return instance;
            });

            return services;
        }
    }
}
