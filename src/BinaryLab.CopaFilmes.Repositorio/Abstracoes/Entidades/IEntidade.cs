using System;
using System.ComponentModel.DataAnnotations;

namespace BinaryLab.CopaFilmes.Repositorio.Abstracoes.Entidades
{
    public interface IEntidade : IEntidade<int>
    { }

    public interface IEntidade<out TKey> where TKey : IEquatable<TKey>
    {
        [Key]
        TKey Id { get; }
    }
}
