using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using BinaryLab.CopaFilmes.Filme.Repositorio.Abstracoes;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes;
using BinaryLab.CopaFilmes.Repositorio.Http;
using BinaryLab.CopaFilmes.Repositorio.Http.Abstracoes;
using JetBrains.Annotations;

namespace BinaryLab.CopaFilmes.Filme.Repositorio
{
    public class FilmeRepositorio : RepositorioHttpLeitura<Entidades.Filme, string>, IFilmeRepositorio
    {
        protected readonly IRepositorioLeitura<Entidades.Filme, string> _repositorioLeitura;

        public FilmeRepositorio(IRepositorioLeitura<Entidades.Filme, string> repositorioLeitura,
            [NotNull] IHttpContexto httpContexto) : base(httpContexto)
        {
            _repositorioLeitura = repositorioLeitura ?? throw new ArgumentNullException(nameof(repositorioLeitura));
            
            if (httpContexto == null)
                throw new ArgumentNullException(nameof(httpContexto));
        }

        public IEnumerable<Entidades.Filme> Obter() => _repositorioLeitura.Obter();

        public async Task<IEnumerable<Entidades.Filme>> ObterAsync() => await _repositorioLeitura.ObterAsync();

        public IEnumerable<Entidades.Filme> Obter(IEnumerable<string> idsFilmes) => _repositorioLeitura.Obter(idsFilmes.ToArray());

        public Task<IEnumerable<Entidades.Filme>> ObterAsync(IEnumerable<string> idsFilmes,
            CancellationToken cancellationToken = default) =>
            _repositorioLeitura.ObterAsync(idsFilmes.ToArray(), cancellationToken);

        public override Entidades.Filme Obter(string chave)
        {
            var conteudo = _repositorioLeitura.Obter();
            return conteudo.FirstOrDefault(i => i.Id.Equals(chave));
        }

        public override async Task<Entidades.Filme> ObterAsync(string chave, CancellationToken cancellationToken = default)
        {
            var conteudo = await _repositorioLeitura.ObterAsync(cancellationToken);
            return conteudo.FirstOrDefault(i => i.Id.Equals(chave));
        }
    }
}
