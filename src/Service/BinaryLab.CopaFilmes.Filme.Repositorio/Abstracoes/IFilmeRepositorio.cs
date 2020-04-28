using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes;

namespace BinaryLab.CopaFilmes.Filme.Repositorio.Abstracoes
{
    public interface IFilmeRepositorio : IRepositorioLeitura<Entidades.Filme, string>
    {
        IEnumerable<Entidades.Filme> Obter();
        Task<IEnumerable<Entidades.Filme>> ObterAsync();
        IEnumerable<Entidades.Filme> Obter(IEnumerable<string> idsFilmes);
        Task<IEnumerable<Entidades.Filme>> ObterAsync(IEnumerable<string> idsFilmes, CancellationToken cancellationToken = default);
    }
}
