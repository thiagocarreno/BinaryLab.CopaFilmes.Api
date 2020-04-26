using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryLab.CopaFilmes.Repositorio.Http.Abstracoes
{
    public interface IHttpContexto
    {
        string UrlRecurso { get; }

        Task<HttpClient> ObterContextoAsync(CancellationToken cancellationToken = default);
        Task<HttpResponseMessage> ObterAsync(string url, CancellationToken cancellationToken = default);
    }
}