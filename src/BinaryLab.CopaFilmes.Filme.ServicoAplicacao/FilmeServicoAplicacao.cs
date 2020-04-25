using BinaryLab.CopaFilmes.Filme.ServicoAplicacao.Abstracoes;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BinaryLab.CopaFilmes.Filme.Repositorio.Abstracoes;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes;
using JetBrains.Annotations;

namespace BinaryLab.CopaFilmes.Filme.ServicoAplicacao
{
    public class FilmeServicoAplicacao : IFilmeServicoAplicacao
    {
        protected readonly IFilmeRepositorio _filmeRepositorio;
        private IMapper _mapper { get; set; }

        public FilmeServicoAplicacao([NotNull] IFilmeRepositorio filmeRepositorio, IMapper mapper)
        {
            _filmeRepositorio = filmeRepositorio ?? throw new ArgumentNullException(nameof(filmeRepositorio));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public IEnumerable<DTO.Filme> ObterFilmes() => ObterFilmesAsync().Result;

        public async Task<IEnumerable<DTO.Filme>> ObterFilmesAsync(CancellationToken cancellationToken = default)
        {
            var filmes = _filmeRepositorio.Obter();
            return _mapper.Map<IEnumerable<DTO.Filme>>(filmes);
        }

        public Dominio.Entidades.Filme ObterVencedor(IEnumerable<int> idsFilmesDisputa)
        {
            if (idsFilmesDisputa == null)
                throw new ArgumentNullException(nameof(idsFilmesDisputa));

            throw new NotImplementedException();
        }
    }
}
