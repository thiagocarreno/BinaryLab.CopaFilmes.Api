using System;
using System.Net.Http;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes;
using BinaryLab.CopaFilmes.Repositorio.Http.Abstracoes;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Polly.Extensions.Http;

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

        public static IServiceCollection AddClienteHttp(this IServiceCollection services,
            [NotNull] ClienteHttpConfiguracao clienteHttpConfiguracao)
        {
            if (clienteHttpConfiguracao == null)
                throw new ArgumentNullException(nameof(clienteHttpConfiguracao));
            
            services.AddHttpClient(clienteHttpConfiguracao.NomeCliente,
                    c => c.BaseAddress = new Uri(clienteHttpConfiguracao.UrlBase))
                .AddPolicyHandler(ConfigurarRetentativasAsync(clienteHttpConfiguracao.Retentativas,
                    clienteHttpConfiguracao.IntervaloRetentativas))
                .AddPolicyHandler(ConfigurarCircuitBreakerAsync(
                    clienteHttpConfiguracao.EventosAntesQuebraCircuitBreaker,
                    clienteHttpConfiguracao.IntervaloCircuitBreaker))
                .SetHandlerLifetime(TimeSpan.FromMinutes(clienteHttpConfiguracao.TempoCicloVida));
            
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

        private static IAsyncPolicy<HttpResponseMessage> ConfigurarRetentativasAsync(int retentativas, double intervaloRetentativas)
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(retentativas, intervalo => TimeSpan.FromSeconds(intervaloRetentativas));
        }

        private static IAsyncPolicy<HttpResponseMessage> ConfigurarCircuitBreakerAsync(int eventosAntesQuebra, double intervalo)
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(eventosAntesQuebra, TimeSpan.FromSeconds(intervalo));
        }
    }
}
