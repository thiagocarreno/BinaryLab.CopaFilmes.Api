using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using BinaryLab.CopaFilmes.Api.Roteamento;
using BinaryLab.CopaFilmes.Api.Versionamento;
using BinaryLab.CopaFilmes.Filme.ServicoAplicacao.Abstracoes;
using BinaryLab.CopaFilmes.Http;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;

namespace BinaryLab.CopaFilmes.Filme.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion(Versoes.V1)]
    [Route(RotasPadrao.RotaVersionada)]
    [Produces(TiposConteudo.Json)]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmeServicoAplicacao _filmeServicoAplicacao;

        public FilmesController([NotNull] IFilmeServicoAplicacao filmeServicoAplicacao)
        {
            _filmeServicoAplicacao = filmeServicoAplicacao ?? throw new ArgumentNullException(nameof(filmeServicoAplicacao));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ServicoAplicacao.DTO.Filme>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObterAsync(CancellationToken cancellationToken)
        {
            var filmes = await _filmeServicoAplicacao.ObterAsync(cancellationToken);
            return Ok(filmes);
        }

        [HttpGet("{idsFilmes}", Name = "ObterVencedoresAsync")]
        [ProducesResponseType((int)HttpStatusCode.NotAcceptable)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<ServicoAplicacao.DTO.Filme>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ObterVencedoresAsync([NotNull] string idsFilmes, CancellationToken cancellationToken)
        {
            var idsFilmesArray = idsFilmes.Split(",");
            if (idsFilmesArray.Length == 0)
                return new StatusCodeResult((int)HttpStatusCode.NotAcceptable);

            var vencedores = await _filmeServicoAplicacao.ObterVencedoresAsync(idsFilmesArray, cancellationToken);
            if (vencedores == null)
                return NotFound();

            return Ok(vencedores);
        }
    }
}
