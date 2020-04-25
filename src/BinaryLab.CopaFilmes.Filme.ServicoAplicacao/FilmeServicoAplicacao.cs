using BinaryLab.CopaFilmes.Filme.ServicoAplicacao.Abstracoes;
using System;
using System.Collections.Generic;
using BinaryLab.CopaFilmes.Filme.Repositorio.Abstracoes;
using BinaryLab.CopaFilmes.Repositorio.Abstracoes;
using JetBrains.Annotations;

namespace BinaryLab.CopaFilmes.Filme.ServicoAplicacao
{
    public class FilmeServicoAplicacao : IFilmeServicoAplicacao
    {
        protected readonly IFilmeRepositorio _filmeRepositorio;

        public FilmeServicoAplicacao([NotNull] IFilmeRepositorio filmeRepositorio)
        {
            _filmeRepositorio = filmeRepositorio ?? throw new ArgumentNullException(nameof(filmeRepositorio));
        }

        public IEnumerable<DTO.Filme> ObterFilmes()
        {
            var filmes = _filmeRepositorio.Obter();

            throw new NotImplementedException();
        }

        public Dominio.Entidades.Filme ObterVencedor(IEnumerable<int> idsFilmesDisputa)
        {
            if (idsFilmesDisputa == null)
                throw new ArgumentNullException(nameof(idsFilmesDisputa));

            throw new NotImplementedException();
        }
    }
}
