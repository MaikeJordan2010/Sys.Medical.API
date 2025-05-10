using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sys.Medical.Aplicacao._Medicos.Comandos;
using Sys.Medical.Aplicacao._Medicos.Consultas;
using Sys.Medical.Dominio.Medico;
using Sys.Medical.Dominio.ViewModel;

namespace Sys.Medical.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoComandos _medicoComandos;
        private readonly IMedicoConsultas _medicoConsultas;
        public MedicoController(IMedicoComandos medicoComandos,
                                IMedicoConsultas medicoConsultas)
        {
            _medicoComandos = medicoComandos;
            _medicoConsultas = medicoConsultas;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Cadastrar")]
        public async Task<IActionResult> Cadastrar(CadastroUsuario cadrastrar) 
        {
            try
            {
                var resultado = await Task.Run(() => _medicoComandos.Cadastrar(cadrastrar));

                if (resultado.Sucesso)
                    return Ok(resultado);

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
        public async Task<IActionResult> Login(LoginUsuario loginUsuario)
        {
            try
            {
                var resultado = await Task.Run(() => _medicoComandos.Logar(loginUsuario));

                if (resultado.Sucesso)
                    return Ok(resultado);

                return BadRequest();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("ObterLista")]
        public async Task<IActionResult> ObterLista()
        {
            try
            {
                var resultado = await Task.Run(() => _medicoConsultas.ObterLista());
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("ObterListaPorEspecialidade/{codEspecilidade}")]
        public async Task<IActionResult> ObterLista(int codEspecilidade)
        {
            try
            {
                var resultado = await Task.Run(() => _medicoConsultas.ObterLista(codEspecilidade));
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
