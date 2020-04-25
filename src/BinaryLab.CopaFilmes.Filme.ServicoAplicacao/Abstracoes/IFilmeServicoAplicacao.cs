using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace BinaryLab.CopaFilmes.Filme.ServicoAplicacao.Abstracoes
{
    public interface IFilmeServicoAplicacao
    {
        IEnumerable<DTO.Filme> Obter();
        Task<IEnumerable<DTO.Filme>> ObterAsync(CancellationToken cancellationToken = default);
        IEnumerable<DTO.Filme> ObterVencedores([NotNull] IEnumerable<string> idsFilmesDisputa);
        Task<IEnumerable<DTO.Filme>> ObterVencedoresAsync([NotNull] IEnumerable<string> idsFilmesDisputa, CancellationToken cancellationToken = default);
    }
}