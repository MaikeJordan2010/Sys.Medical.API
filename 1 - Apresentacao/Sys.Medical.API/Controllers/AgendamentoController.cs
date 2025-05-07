using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sys.Medical.Aplicacao._Agenda.Comandos;
using Sys.Medical.Aplicacao._Agenda.Consultas;
using Sys.Medical.Dominio.DTOs;
using Sys.Medical.Dominio.Medico;
using Sys.Medical.Dominio.Paciente;
using Sys.Medical.Dominio.ViewModel;

namespace Sys.Medical.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
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
        [Route("CadastrarAgendaMensal")]
        public async Task<IActionResult> CadastrarAgendaMensal(AgendaMensal
            agenda)
        {
            try
            {
                var resultado = await Task.Run(() => _comandos.CriarAgendaMensal(agenda));

                if (resultado.Sucesso)
                    return Ok(resultado);

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        [Route("AgendarConsultaPaciente")]
        public async Task<IActionResult> AgendarConsultaPaciente(AgendarConsultaPaciente agendaConsulta)
        {
            try
            {
                var resultado = await Task.Run(() => _comandos.AgendarConsultaPaciente(agendaConsulta));

                if (resultado.Sucesso)
                    return Ok(resultado);

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> Atualizar(Agenda agenda)
        {
            try
            {
                var resultado = await Task.Run(() => _comandos.Atualizar(agenda));

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

        [HttpPost]
        [Route("ObterPorFiltro")]
        public async Task<IActionResult> ObterPorFiltro(FiltroAgenda filtro)
        {
            try
            {
                var resultado = await Task.Run(() => _consultas.ObterPorFiltro(filtro));
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
