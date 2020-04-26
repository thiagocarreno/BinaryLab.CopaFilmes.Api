using System;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes.Entidades;

namespace BinaryLab.CopaFilmes.Repositorio.Entidades
{
    public class Entidade : Entidade<int>
    {
    }

    public class Entidade<TChave> : IEntidade<TChave>
        where TChave : IEquatable<TChave>
    {
        public TChave Id { get; protected set; }
    }
}
