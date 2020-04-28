using System;
using System.ComponentModel.DataAnnotations;

namespace BinaryLab.CopaFilmes.Repositorio.Abstracoes.Entidades
{
    public interface IEntidade : IEntidade<int>
    { }

    public interface IEntidade<out TChave> where TChave : IEquatable<TChave>
    {
        [Key]
        TChave Id { get; }
    }
}
