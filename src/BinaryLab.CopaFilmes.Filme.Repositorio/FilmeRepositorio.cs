using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BinaryLab.CopaFilmes.Filme.Repositorio.Abstracoes;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes;
using BinaryLab.CopaFilmes.Repositorio.Http;

namespace BinaryLab.CopaFilmes.Filme.Repositorio
{
    public class FilmeRepositorio : RepositorioHttpLeitura<Entidades.Filme, string>, IFilmeRepositorio
    {
        protected readonly IRepositorioLeitura<Entidades.Filme, string> _repositorioLeitura;

        public FilmeRepositorio(IRepositorioLeitura<Entidades.Filme, string> repositorioLeitura)
        {
            _repositorioLeitura = repositorioLeitura ?? throw new ArgumentNullException(nameof(repositorioLeitura));
        }

        public IEnumerable<Entidades.Filme> Obter() => _repositorioLeitura.Obter();

        public async Task<IEnumerable<Entidades.Filme>> ObterAsync() => await _repositorioLeitura.ObterAsync();

        public IEnumerable<Entidades.Filme> Obter(IEnumerable<string> idsFilmes) => _repositorioLeitura.Obter(idsFilmes.ToArray());

        public Task<IEnumerable<Entidades.Filme>> ObterAsync(IEnumerable<string> idsFilmes,
            CancellationToken cancellationToken = default) =>
            _repositorioLeitura.ObterAsync(idsFilmes.ToArray(), cancellationToken);
    }
}
