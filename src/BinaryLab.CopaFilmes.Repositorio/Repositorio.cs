using System;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes.Entidades;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace BinaryLab.CopaFilmes.Repositorio
{
    public class Repositorio<TEntidade> : Repositorio<TEntidade, int>, IRepositorio<TEntidade>
        where TEntidade : class, IEntidade<int>
    {
        public Repositorio([NotNull] IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }

    public class Repositorio<TEntidade, TChave> : IRepositorio<TEntidade, TChave>
        where TEntidade : class, IEntidade<TChave>
        where TChave : IEquatable<TChave>
    {
        public IRepositorioLeitura<TEntidade, TChave> Leitura { get; }

        public Repositorio([NotNull] IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));

            Leitura = serviceProvider.GetService<IRepositorioLeitura<TEntidade, TChave>>();
        }
    }
}
