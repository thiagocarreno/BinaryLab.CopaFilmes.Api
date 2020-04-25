using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace BinaryLab.CopaFilmes.Filme.Dominio.Abstracoes
{
    public interface IFilmeDominio
    {
        IEnumerable<Entidade.Filme> Ordenar([NotNull] IEnumerable<Entidade.Filme> filmes);
        Task<IEnumerable<Entidade.Filme>> OrdenarAsync([NotNull] IEnumerable<Entidade.Filme> filmes);
        int CalcularDisputas([NotNull] IEnumerable<Entidade.Filme> filmes);
        Task<int> CalcularDisputasAsync([NotNull] IEnumerable<Entidade.Filme> filmes);
        int ObterUltimoIndex(int quantidadeFilmes, int index);
        Task<int> ObterUltimoIndexAsync(int quantidadeFilmes, int index);
        Entidade.Filme ObterVencedor([NotNull] Entidade.Filme primeiroFilmeDisputa, [NotNull] Entidade.Filme segundoFilmeDisputa);
        Task<Entidade.Filme> ObterVencedorAsync([NotNull] Entidade.Filme primeiroFilmeDisputa, [NotNull] Entidade.Filme segundoFilmeDisputa);
        IEnumerable<Entidade.Filme> Disputar([NotNull] IEnumerable<Entidade.Filme> filmes);
        Task<IEnumerable<Entidade.Filme>> DisputarAsync([NotNull] IEnumerable<Entidade.Filme> filmes);
    }
}