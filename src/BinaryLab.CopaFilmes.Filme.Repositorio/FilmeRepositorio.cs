using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BinaryLab.CopaFilmes.Filme.Repositorio.Abstracoes;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes;
using BinaryLab.CopaFilmes.Repositorio.Http;
using JetBrains.Annotations;

namespace BinaryLab.CopaFilmes.Filme.Repositorio
{
    public class FilmeRepositorio : RepositorioHttpLeitura<Entidades.Filme, string>, IFilmeRepositorio
    {
        protected readonly IRepositorioLeitura<Entidades.Filme, string> _repositorioLeitura;

        public FilmeRepositorio(IRepositorioLeitura<Entidades.Filme, string> repositorioLeitura,
            [NotNull] IHttpClientFactory httpClientFactory, [NotNull] Uri uriRecurso) : base(httpClientFactory, uriRecurso)
        {
            _repositorioLeitura = repositorioLeitura ?? throw new ArgumentNullException(nameof(repositorioLeitura));
            
            if (httpClientFactory == null)
                throw new ArgumentNullException(nameof(httpClientFactory));
            
            if (uriRecurso == null)
                throw new ArgumentNullException(nameof(uriRecurso));
        }

        public IEnumerable<Entidades.Filme> Obter() => _repositorioLeitura.Obter();

        public async Task<IEnumerable<Entidades.Filme>> ObterAsync() => await _repositorioLeitura.ObterAsync();

        public IEnumerable<Entidades.Filme> Obter(IEnumerable<string> idsFilmes) => _repositorioLeitura.Obter(idsFilmes.ToArray());

        public Task<IEnumerable<Entidades.Filme>> ObterAsync(IEnumerable<string> idsFilmes,
            CancellationToken cancellationToken = default) =>
            _repositorioLeitura.ObterAsync(idsFilmes.ToArray(), cancellationToken);
    }
}
