using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace BinaryLab.CopaFilmes.Filme.ServicoAplicacao.Abstracoes
{
    public interface IFilmeServicoAplicacao
    {
        IEnumerable<DTO.Filme> ObterFilmes();
        Task<IEnumerable<DTO.Filme>> ObterFilmesAsync(CancellationToken cancellationToken = default);
        Dominio.Entidades.Filme ObterVencedor([NotNull] IEnumerable<int> idsFilmesDisputa);
    }
}