using System;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes.Entidades;

namespace BinaryLab.CopaFilmes.Repositorio.Abstracoes
{
    public interface IRepositorio<TEntidade> : IRepositorio<TEntidade, int>
        where TEntidade : class, IEntidade<int>
    { }
    public interface IRepositorio<TEntidade, in TKey>
        where TEntidade : class, IEntidade<TKey>
        where TKey : IEquatable<TKey>
    {
        IRepositorioLeitura<TEntidade, TKey> Leitor { get; }
    }
}
