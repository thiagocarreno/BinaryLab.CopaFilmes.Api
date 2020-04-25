using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes.Entidades;

namespace BinaryLab.CopaFilmes.Repositorio.Http
{
    //TODO: Implementar
    public class RepositorioHttpLeitura<TEntidade> : RepositorioHttpLeitura<TEntidade, int>, IRepositorioLeitura<TEntidade>
        where TEntidade : class, IEntidade<int>
    {
        public RepositorioHttpLeitura()
        {
        }
    }

    public class RepositorioHttpLeitura<TEntidade, TChave> : IRepositorioLeitura<TEntidade, TChave>
        where TEntidade : class, IEntidade<TChave>
        where TChave : IEquatable<TChave>
    {

        public async Task<TEntidade> GetAsync(TChave key, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntidade> GetAsync(CancellationToken cancellationToken = default, params object[] keys)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntidade>> GetAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntidade>> FindAsync(Expression<Func<TEntidade, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
