using Microsoft.AspNetCore.Mvc;
using Sys.Medical.Aplicacao._Especialidades.Consultas;

namespace Sys.Medical.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EspecialidadesController(IEspecialidadeConsultas consultas) : ControllerBase
    {
        private readonly IEspecialidadeConsultas _consultas = consultas;

        [HttpGet]
        [Route("ObterLista")]
        public async Task<IActionResult> ObterLista()
        {
            try
            {
                var resultado = await Task.Run(() => _consultas.ObterLista());
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
