using Atividade01.Dominio.Sistemicas;
using Sys.Medical.Aplicacao._Paciente.Validadores;
using Sys.Medical.Aplicacao._Paciente.Validadores;
using Sys.Medical.Dominio.Paciente;
using Sys.Medical.Dominio.Sistemicas;
using Sys.Medical.Dominio.ViewModel;
using Sys.Medical.Repositorio.Repositorios.PacienteRepositorio.Comandos;
using Sys.Medical.Repositorio.Repositorios.PacienteRepositorio.Consultas;

namespace Sys.Medical.Aplicacao._Paciente.Comandos
{
    public class PacienteComandos : IPacienteComandos
    {
        private readonly IPacienteComandosRepositorio _pacienteComandosRepositorio;
        private readonly IPacienteConsultasRepositorio _pacienteConsultasRepositorio;

        public PacienteComandos(IPacienteComandosRepositorio pacienteComandosRepositorio,
                                IPacienteConsultasRepositorio pacienteConsultasRepositorio)
        {
            _pacienteComandosRepositorio = pacienteComandosRepositorio;
            _pacienteConsultasRepositorio = pacienteConsultasRepositorio;
        }
        public ResultadoGenericoComandos Atualizar(Paciente paciente)
        {
            var validador = new ValidarAtualizarPaciente().Validate(paciente);

            if(validador.IsValid)
            {
                var pacienteAtual = _pacienteConsultasRepositorio.ObterPorCod(paciente.CodPaciente!);

                if (paciente == null)
                    return ResultadoGenericoComandos.Erro();

                _pacienteComandosRepositorio.Atualizar(paciente);
                return ResultadoGenericoComandos.Ok();
            }
            return ResultadoGenericoComandos.Erro(validador.Errors);

        }

        public ResultadoGenericoComandos Criar(CadastroPaciente pacienteEntrada)
        {
            var validador = new ValidarCriarUsuarioPaciente().Validate(pacienteEntrada);

            if (validador == null)
                return ResultadoGenericoComandos.ErroLogin();

            var paciente = new Paciente(pacienteEntrada);

            _pacienteComandosRepositorio.Inserir(paciente);
            paciente.Senha = null;
            return ResultadoGenericoComandos.Ok(paciente);


        }

        public ResultadoGenericoComandos Logar(LoginUsuario usuario)
        {
            try
            {
                var validador = new Validadores.ValidarLoginUsuarioPaciente().Validate(usuario);

                if (validador.IsValid)
                {
                    var paciente = _pacienteConsultasRepositorio.ObterPorEmailOuCPF(usuario.Usuario!);

                    if (paciente == null)
                        return ResultadoGenericoComandos.ErroLogin();

                    var senhaHash = GerenciarSenhas.ComputeHash(paciente.Senha!);

                    if (senhaHash != paciente?.Senha)
                        return ResultadoGenericoComandos.ErroLogin();

                    paciente.Senha = null;

                    return ResultadoGenericoComandos.Ok(paciente);

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
