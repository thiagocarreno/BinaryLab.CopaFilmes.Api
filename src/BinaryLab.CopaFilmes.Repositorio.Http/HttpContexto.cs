using BinaryLab.CopaFilmes.Repositorio.Http.Abstracoes;
using JetBrains.Annotations;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryLab.CopaFilmes.Repositorio.Http
{
    public class HttpContexto : IHttpContexto
    {
        public string UrlRecurso { get; }

        private volatile HttpClient _httpClient;
        private volatile string _urlEntidade;

        public HttpContexto([NotNull] IHttpClientFactory httpClientFactory, [NotNull] string nomeCliente, [NotNull] string urlRecurso)
        {
            if (httpClientFactory == null)
                throw new ArgumentNullException(nameof(httpClientFactory));

            if (nomeCliente == null)
                throw new ArgumentNullException(nameof(nomeCliente));

            if (urlRecurso == null)
                throw new ArgumentNullException(nameof(urlRecurso));

            _httpClient = httpClientFactory.CreateClient(nomeCliente);
            UrlRecurso = urlRecurso;
        }

        public virtual Task<HttpClient> ObterContextoAsync(CancellationToken cancellationToken = default) => Task.FromResult(_httpClient);

        public virtual async Task<HttpResponseMessage> ObterAsync(string url, CancellationToken cancellationToken = default)
        {
            try
            {
                var cliente = await ObterContextoAsync(cancellationToken);
                return await cliente.GetAsync(url);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}
