using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sys.Medical.Aplicacao._Agenda.Comandos;
using Sys.Medical.Aplicacao._Agenda.Consultas;
using Sys.Medical.Dominio.DTOs;
using Sys.Medical.Dominio.Medico;
using Sys.Medical.Dominio.Paciente;

namespace Sys.Medical.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoComandos _comandos;
        private readonly IAgendamentoConsultas _consultas;
        public AgendamentoController(IAgendamentoComandos comandos,
                                     IAgendamentoConsultas consultas)
        {
            _comandos = comandos;
            _consultas = consultas;
        }


        [HttpPost]
        [Route("Cadastrar")]
        public async Task<IActionResult> Cadastrar(Agenda agenda)
        {
            try
            {
                var resultado = await Task.Run(() => _comandos.Criar(agenda));

                if (resultado.Sucesso)
                    return Ok(resultado);

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPost]
        [Route("AprovarAgenda")]
        public async Task<IActionResult> AprovarAgenda(string codAgenda)
        {
            try
            {
                var resultado = await Task.Run(() => _comandos.AprovarAgenda(codAgenda));

                if (resultado.Sucesso)
                    return Ok(resultado);

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPost]
        [Route("CancelarAgenda")]
        public async Task<IActionResult> CancelarAgenda(string codAgenda)
        {
            try
            {
                var resultado = await Task.Run(() => _comandos.CancelarAgenda(codAgenda));

                if (resultado.Sucesso)
                    return Ok(resultado);

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


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


        [HttpGet("ObterListaPorMedico/{codMedico}")]
        public async Task<IActionResult> ObterListaPorMedico(string codMedico)
        {
            try
            {
                var resultado = await Task.Run(() => _consultas.ObterPorMedico(codMedico));
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("ObterListaPorPaciente/{codPaciente}")]
        public async Task<IActionResult> ObterListaPorPaciente(string codPaciente)
        {
            try
            {
                var resultado = await Task.Run(() => _consultas.ObterPorPaciente(codPaciente));
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("ObterAgenda/{codAgenda}")]
        public async Task<IActionResult> ObterAgenda(string codAgenda)
        {
            try
            {
                var resultado = await Task.Run(() => _consultas.ObterAgendaSaida(codAgenda));
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
