using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BinaryLab.CopaFilmes.Filme.Api.Controllers
{
    //TODO: Implementar Facilitadores
    //TODO: Implementar Notification Handler
    //TODO: Implementar Chamadas
    //TODO: Implementar IOC
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ObterAsync()
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ObterVencedoresAsync([FromBody] string[] idsFilmes)
        {
            return Ok();
        }
    }
}
