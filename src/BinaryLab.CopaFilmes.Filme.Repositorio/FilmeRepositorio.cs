using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Entidades.Filme>> ObterAsync()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Entidades.Filme> Obter(string[] idsFilmes)
        {
            throw new System.NotImplementedException();
        }
    }
}
