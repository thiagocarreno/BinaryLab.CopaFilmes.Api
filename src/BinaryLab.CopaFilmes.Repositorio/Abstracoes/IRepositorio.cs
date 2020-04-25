using System;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes.Entidades;

namespace BinaryLab.CopaFilmes.Repositorio.Abstracoes
{
    public interface IRepositorio<TEntidade> : IRepositorio<TEntidade, int>
        where TEntidade : class, IEntidade<int>
    { }

    public interface IRepositorio<TEntidade, in TChave>
        where TEntidade : class, IEntidade<TChave>
        where TChave : IEquatable<TChave>
    {
        IRepositorioLeitura<TEntidade, TChave> Leitura { get; }
    }
}
