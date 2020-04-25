using System;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes.Entidades;

namespace BinaryLab.CopaFilmes.Repositorio.Entidades
{
    public class Entidade : Entidade<int>
    {
    }

    public class Entidade<TKey> : IEntidade<TKey>
        where TKey : IEquatable<TKey>
    {
        public TKey Id { get; }
    }
}
