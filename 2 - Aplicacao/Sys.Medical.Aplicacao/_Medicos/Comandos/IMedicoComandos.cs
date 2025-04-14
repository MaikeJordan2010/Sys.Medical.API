using Atividade01.Dominio.Sistemicas;
using Sys.Medical.Dominio.Medico;
using Sys.Medical.Dominio.ViewModel;

namespace Sys.Medical.Aplicacao._Medicos.Comandos
{
    public interface IMedicoComandos
    {
        public ResultadoGenericoComandos Cadastrar(CadastroUsuario usuarioEntrada);
        public ResultadoGenericoComandos Logar(LoginUsuario usuarioEntrada);

       // public ResultadoGenericoComandos AtualizarCadastro(CadastroUsuario usuarioEntrada);

    }
}
