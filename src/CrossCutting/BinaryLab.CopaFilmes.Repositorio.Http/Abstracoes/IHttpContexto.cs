using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryLab.CopaFilmes.Repositorio.Http.Abstracoes
{
    public interface IHttpContexto
    {
        Task<HttpClient> ObterContextoAsync(CancellationToken cancellationToken = default);
        Task<HttpResponseMessage> ObterAsync(CancellationToken cancellationToken = default);
    }
}