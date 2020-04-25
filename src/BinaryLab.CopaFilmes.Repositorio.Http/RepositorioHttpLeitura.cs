using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes.Entidades;

namespace BinaryLab.CopaFilmes.Repositorio.Http
{
    public class RepositorioHttpLeitura<TEntidade> : RepositorioHttpLeitura<TEntidade, int>, IRepositorioLeitura<TEntidade>
        where TEntidade : class, IEntidade<int>
    {
        public RepositorioHttpLeitura() : base()
        {
        }
    }

    public class RepositorioHttpLeitura<TEntidade, TChave> : IRepositorioLeitura<TEntidade, TChave>
        where TEntidade : class, IEntidade<TChave>
        where TChave : IEquatable<TChave>
    {
        public RepositorioHttpLeitura()
        {
        }


        public TEntidade Obter(TChave key)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntidade> ObterAsync(TChave key, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntidade> Obter(TChave[] keys)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntidade>> ObterAsync(TChave[] keys, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntidade> Obter()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntidade>> ObterAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntidade> Find(Expression<Func<TEntidade, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntidade>> FindAsync(Expression<Func<TEntidade, bool>> predicate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
