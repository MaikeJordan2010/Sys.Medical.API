using Atividade01.Dominio.Sistemicas;
using Sys.Medical.Dominio.Paciente;
using Sys.Medical.Dominio.ViewModel;

namespace Sys.Medical.Aplicacao._Paciente.Comandos
{
    public interface IPacienteComandos
    {
        public ResultadoGenericoComandos Atualizar(Paciente paciente);
        public ResultadoGenericoComandos Criar(CadastroPaciente pacienteEntrada);
        public ResultadoGenericoComandos Logar(LoginUsuario usuario);

    }
}
