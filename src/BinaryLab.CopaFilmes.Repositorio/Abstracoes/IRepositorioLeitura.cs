using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes.Entidades;

namespace BinaryLab.CopaFilmes.Repositorio.Abstracoes
{
    public interface IRepositorioLeitura<TEntidade> : IRepositorioLeitura<TEntidade, int>
        where TEntidade : class, IEntidade<int>
    { }

    public interface IRepositorioLeitura<TEntidade, in TKey>
        where TEntidade : class, IEntidade<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<TEntidade> GetAsync(TKey key, CancellationToken cancellationToken = default);
        Task<TEntidade> GetAsync(CancellationToken cancellationToken = default, params object[] keys);
        Task<IEnumerable<TEntidade>> GetAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<TEntidade>> FindAsync(Expression<Func<TEntidade, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
