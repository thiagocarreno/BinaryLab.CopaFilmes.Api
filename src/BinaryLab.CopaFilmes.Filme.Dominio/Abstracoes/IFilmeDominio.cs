using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace BinaryLab.CopaFilmes.Filme.Dominio.Abstracoes
{
    public interface IFilmeDominio
    {
        IEnumerable<Entidades.Filme> Ordenar([NotNull] IEnumerable<Entidades.Filme> filmes);
        Task<IEnumerable<Entidades.Filme>> OrdenarAsync([NotNull] IEnumerable<Entidades.Filme> filmes,
            CancellationToken cancellationToken = default);
        int CalcularDisputas([NotNull] IEnumerable<Entidades.Filme> filmes);
        Task<int> CalcularDisputasAsync([NotNull] IEnumerable<Entidades.Filme> filmes, CancellationToken cancellationToken = default);
        int ObterUltimoIndex(int quantidadeFilmes, int index);
        Task<int> ObterUltimoIndexAsync(int quantidadeFilmes, int index, CancellationToken cancellationToken = default);
        Entidades.Filme ObterVencedor([NotNull] Entidades.Filme primeiroFilmeDisputa, [NotNull] Entidades.Filme segundoFilmeDisputa);
        Task<Entidades.Filme> ObterVencedorAsync([NotNull] Entidades.Filme primeiroFilmeDisputa,
            [NotNull] Entidades.Filme segundoFilmeDisputa, CancellationToken cancellationToken = default);
        IEnumerable<Entidades.Filme> Disputar([NotNull] IEnumerable<Entidades.Filme> filmes);
        Task<IEnumerable<Entidades.Filme>> DisputarAsync([NotNull] IEnumerable<Entidades.Filme> filmes,
            CancellationToken cancellationToken = default);
    }
}