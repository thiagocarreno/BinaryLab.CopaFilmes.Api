using System.Threading.Tasks;
using BinaryLab.CopaFilmes.Api.Routing;
using BinaryLab.CopaFilmes.Api.Versioning;
using BinaryLab.CopaFilmes.Http;
using Microsoft.AspNetCore.Mvc;

namespace BinaryLab.CopaFilmes.Filme.Api.Controllers.v1
{
    //TODO: Implementar Notification Handler
    //TODO: Implementar Chamadas
    //TODO: Implementar IOC
    [ApiController]
    [ApiVersion(Versoes.V1)]
    [Route(RotasPadrao.RotaVersionada)]
    [Produces(TiposConteudo.Json)]
    public class FilmesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ObterAsync()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> ObterVencedoresAsync([FromBody] string[] idsFilmes)
        {
            return Ok();
        }
    }
}
