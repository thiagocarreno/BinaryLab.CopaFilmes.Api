using System.Collections.Generic;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes;

namespace BinaryLab.CopaFilmes.Filme.Repositorio.Abstracoes
{
    public interface IFilmeRepositorio : IRepositorioLeitura<Entidades.Filme, string>
    {
        IEnumerable<Entidades.Filme> Obter();
    }
}
