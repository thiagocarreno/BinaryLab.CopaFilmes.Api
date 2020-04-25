using BinaryLab.CopaFilmes.Repositorio.Abstracoes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryLab.CopaFilmes.Repositorio.Abstracoes
{
    public interface IRepositorioLeitura<TEntidade> : IRepositorioLeitura<TEntidade, int>
        where TEntidade : class, IEntidade<int>
    { }

    public interface IRepositorioLeitura<TEntidade, in TKey>
        where TEntidade : class, IEntidade<TKey>
        where TKey : IEquatable<TKey>
    {
        TEntidade Obter(TKey key);
        Task<TEntidade> ObterAsync(TKey key, CancellationToken cancellationToken = default);
        TEntidade Obter(params object[] keys);
        Task<TEntidade> ObterAsync(CancellationToken cancellationToken = default, params object[] keys);
        IEnumerable<TEntidade> Obter();
        Task<IEnumerable<TEntidade>> ObterAsync(CancellationToken cancellationToken = default);
        IEnumerable<TEntidade> Find(Expression<Func<TEntidade, bool>> predicate);
        Task<IEnumerable<TEntidade>> FindAsync(Expression<Func<TEntidade, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
