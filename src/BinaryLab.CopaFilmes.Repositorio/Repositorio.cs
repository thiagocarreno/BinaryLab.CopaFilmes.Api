using System;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes.Entidades;
using Microsoft.Extensions.DependencyInjection;

namespace BinaryLab.CopaFilmes.Repositorio
{
    public class Repositorio<TEntidade> : Repositorio<TEntidade, int>, IRepositorio<TEntidade>
        where TEntidade : class, IEntidade<int>
    {
        public Repositorio(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }

    public class Repositorio<TEntidade, TKey> : IRepositorio<TEntidade, TKey>
        where TEntidade : class, IEntidade<TKey>
        where TKey : IEquatable<TKey>
    {
        public IRepositorioLeitura<TEntidade, TKey> Leitor { get; }

        public Repositorio(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));

            Leitor = serviceProvider.GetService<IRepositorioLeitura<TEntidade, TKey>>();
        }
    }
}
