using System.Collections.Generic;
using BinaryLab.CopaFilmes.Filme.Repositorio.Abstracoes;
using BinaryLab.CopaFilmes.Repositorio.Http;

namespace BinaryLab.CopaFilmes.Filme.Repositorio
{
    public class FilmeRepositorio : RepositorioHttpLeitura<Entidades.Filme, string>, IFilmeRepositorio
    {
        public IEnumerable<Entidades.Filme> Obter()
        {
            throw new System.NotImplementedException();
        }
    }
}
