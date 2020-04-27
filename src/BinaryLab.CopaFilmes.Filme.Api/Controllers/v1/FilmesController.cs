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
    //TODO: Implementar Notification Handler
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
        public async Task<IActionResult> ObterAsync(CancellationToken cancellationToken = default)
        {
            var filmes = await _filmeServicoAplicacao.ObterAsync(cancellationToken);
            return Ok(filmes);
        }

        //[HttpGet]
        //[ProducesResponseType((int)HttpStatusCode.NotFound)]
        //[ProducesResponseType(typeof(IEnumerable<ServicoAplicacao.DTO.Filme>), (int)HttpStatusCode.OK)]
        //public async Task<IActionResult> ObterVencedoresAsync([FromBody] string[] idsFilmes, CancellationToken cancellationToken = default)
        //{
        //    var vencedores = await _filmeServicoAplicacao.ObterVencedoresAsync(idsFilmes, cancellationToken);
        //    if (vencedores == null)
        //        return NotFound();

        //    return Ok(vencedores);
        //}
    }
}
