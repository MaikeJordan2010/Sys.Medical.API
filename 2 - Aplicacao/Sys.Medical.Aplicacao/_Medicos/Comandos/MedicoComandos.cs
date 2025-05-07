using Atividade01.Dominio.Sistemicas;
using Sys.Medical.Aplicacao._Medicos.Validadores;
using Sys.Medical.Dominio.DTOs;
using Sys.Medical.Dominio.Medico;
using Sys.Medical.Dominio.Sistemicas;
using Sys.Medical.Dominio.ViewModel;
using Sys.Medical.Repositorio.Repositorios.MedicosRepositorio.Comandos;
using Sys.Medical.Repositorio.Repositorios.MedicosRepositorio.Consultas;

namespace Sys.Medical.Aplicacao._Medicos.Comandos
{
    public class MedicoComandos : IMedicoComandos
    {
        private readonly IMedicoComandosRepositorio _medicoComandosRepositorio;
        private readonly IMedicoConsultasRepositorio _medicoConsultasRepositorio;
        public MedicoComandos(IMedicoComandosRepositorio medicoComandosRepositorio,
                            IMedicoConsultasRepositorio medicoConsultasRepositorio)
        {
            _medicoComandosRepositorio = medicoComandosRepositorio;
            _medicoConsultasRepositorio = medicoConsultasRepositorio;
        }

        public ResultadoGenericoComandos Cadastrar(CadastroUsuario usuarioEntrada)
        {
            try
            {
                var validador = new ValidarCadastrarUsuarios().Validate(usuarioEntrada);

                if (validador.IsValid) 
                {
                    var medico = new Medico(usuarioEntrada);
                    _medicoComandosRepositorio.Inserir(medico);
                    return ResultadoGenericoComandos.Ok(medico);
                }
                return ResultadoGenericoComandos.Erro(validador.Errors);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ResultadoGenericoComandos Logar(LoginUsuario usuarioEntrada)
        {
            try
            {
                var validador = new ValidarLoginUsuarioMedico().Validate(usuarioEntrada);

                if (validador.IsValid)
                {
                    var medico = _medicoConsultasRepositorio.ObterPorUsuario(usuarioEntrada.Usuario!);

                    if (medico == null)
                        return ResultadoGenericoComandos.ErroLogin();

                    var senhaHash = GerenciarSenhas.ComputeHash(usuarioEntrada.Senha!);

                    if(senhaHash != medico?.Senha)
                        return ResultadoGenericoComandos.ErroLogin();

                    medico.Senha = null;
                    string? token = TokenKey.GetToken(medico.NomeMedico!, medico.CodMedico!, medico.Email!, EnumTipoAcesso.MEDICO);

                    return ResultadoGenericoComandos.Ok(new { medico = medico, token = token });
                    
                }
                return ResultadoGenericoComandos.Erro(validador.Errors);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
