using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sys.Medical.Aplicacao._Paciente.Comandos;
using Sys.Medical.Aplicacao._Paciente.Consultas;
using Sys.Medical.Dominio.Paciente;
using Sys.Medical.Dominio.ViewModel;

namespace Sys.Medical.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteComandos _comandos;
        private readonly IPacienteConsultas _consultas;

        public PacienteController(IPacienteComandos comandos,
                                  IPacienteConsultas consultas)
        {
            _comandos = comandos;
            _consultas = consultas;
        }

        [Authorize]
        [HttpPost]
        [Route("Cadastrar")]
        public async Task<IActionResult> Cadastrar(CadastroPaciente cadastroPaciente)
        {
            try
            {
                var resultado = await Task.Run(() => _comandos.Criar(cadastroPaciente));

                if (resultado.Sucesso)
                {
                    return Ok(resultado);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUsuario login)
        {
            try
            {
                var resultado = await Task.Run(() => _comandos.Logar(login));

                if (resultado.Sucesso)
                {
                    return Ok(resultado);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize]
        [HttpPut]
        [Route("Atualizar")]
        public async Task<IActionResult> Atualizar(Paciente paciente)
        {
            try
            {
                var resultado = await Task.Run(() => _comandos.Atualizar(paciente));

                if (resultado.Sucesso)
                {
                    return Ok(resultado);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("ObterPorCod/{codPaciente}")]
        public async Task<IActionResult> ObterPorCod(string codPaciente)
        {
            try
            {
                var resultado = await Task.Run(() => _consultas.ObterPorCod(codPaciente));
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
