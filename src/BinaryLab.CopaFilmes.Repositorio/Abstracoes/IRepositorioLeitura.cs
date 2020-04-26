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

    public interface IRepositorioLeitura<TEntidade, in TChave>
        where TEntidade : class, IEntidade<TChave>
        where TChave : IEquatable<TChave>
    {
        IEnumerable<TEntidade> Obter();
        Task<IEnumerable<TEntidade>> ObterAsync(CancellationToken cancellationToken = default);
        TEntidade Obter(TChave chave);
        Task<TEntidade> ObterAsync(TChave chave, CancellationToken cancellationToken = default);
        IEnumerable<TEntidade> Obter(TChave[] chaves);
        Task<IEnumerable<TEntidade>> ObterAsync(TChave[] chaves, CancellationToken cancellationToken = default);
        IEnumerable<TEntidade> Find(Expression<Func<TEntidade, bool>> predicate);
        Task<IEnumerable<TEntidade>> FindAsync(Expression<Func<TEntidade, bool>> predicate, CancellationToken cancellationToken = default);
    }
}
