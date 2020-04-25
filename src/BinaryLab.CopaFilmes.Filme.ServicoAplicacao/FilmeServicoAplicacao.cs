using BinaryLab.CopaFilmes.Filme.ServicoAplicacao.Abstracoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BinaryLab.CopaFilmes.Filme.Dominio.Abstracoes;
using BinaryLab.CopaFilmes.Filme.Repositorio.Abstracoes;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes;
using JetBrains.Annotations;

namespace BinaryLab.CopaFilmes.Filme.ServicoAplicacao
{
    public class FilmeServicoAplicacao : IFilmeServicoAplicacao
    {
        protected readonly IFilmeDominio _filmeDominio;
        protected readonly IFilmeRepositorio _filmeRepositorio;
        private IMapper _mapper { get; set; }

        public FilmeServicoAplicacao([NotNull] IFilmeRepositorio filmeRepositorio, IMapper mapper, IFilmeDominio filmeDominio = default)
        {
            _filmeRepositorio = filmeRepositorio ?? throw new ArgumentNullException(nameof(filmeRepositorio));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _filmeDominio = filmeDominio;
        }

        public IEnumerable<DTO.Filme> Obter() 
        {
            var filmes = _filmeRepositorio.Obter();
            return _mapper.Map<IEnumerable<DTO.Filme>>(filmes);
        }

        public async Task<IEnumerable<DTO.Filme>> ObterAsync(CancellationToken cancellationToken = default)
        {
            var filmes = await _filmeRepositorio.ObterAsync();
            return _mapper.Map<IEnumerable<DTO.Filme>>(filmes);
        }

        public IEnumerable<DTO.Filme> ObterVencedores(IEnumerable<string> idsFilmesDisputa)
        {
            if (idsFilmesDisputa == null)
                throw new ArgumentNullException(nameof(idsFilmesDisputa));

            var filmes = _filmeRepositorio.Obter(idsFilmesDisputa);
            var filmesMapeados = _mapper.Map<IEnumerable<Dominio.Entidades.Filme>>(filmes);
            var vencedores = _filmeDominio.ObterVencedores(filmesMapeados);
            return _mapper.Map<IEnumerable<DTO.Filme>>(vencedores);
        }

        public async Task<IEnumerable<DTO.Filme>> ObterVencedoresAsync(IEnumerable<string> idsFilmesDisputa, CancellationToken cancellationToken = default)
        {
            if (idsFilmesDisputa == null)
                throw new ArgumentNullException(nameof(idsFilmesDisputa));

            var filmes = await _filmeRepositorio.ObterAsync(cancellationToken, idsFilmesDisputa);
            var filmesMapeados = _mapper.Map<IEnumerable<Dominio.Entidades.Filme>>(filmes);
            var vencedores = await _filmeDominio.ObterVencedoresAsync(filmesMapeados);
            return _mapper.Map<IEnumerable<DTO.Filme>>(vencedores);
        }
    }
}
