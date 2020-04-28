using BinaryLab.CopaFilmes.Repositorio.Http.Abstracoes;
using JetBrains.Annotations;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryLab.CopaFilmes.Repositorio.Http
{
    public class ContextoHttp : IHttpContexto
    {
        private volatile HttpClient _clienteHttp;
        private volatile string _urlRecursoApi;

        public ContextoHttp([NotNull] HttpClient clienteHttp, [NotNull] string urlRecursoApi)
        {
            _urlRecursoApi = urlRecursoApi ?? throw new ArgumentNullException(nameof(urlRecursoApi));
            _clienteHttp = clienteHttp ?? throw new ArgumentNullException(nameof(clienteHttp));
        }

        public virtual Task<HttpClient> ObterContextoAsync(CancellationToken cancellationToken = default) => Task.FromResult(_clienteHttp);

        public virtual async Task<HttpResponseMessage> ObterAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var cliente = await ObterContextoAsync(cancellationToken);
                return await cliente.GetAsync($"{_clienteHttp.BaseAddress}/{_urlRecursoApi}");
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
        }
    }
}
