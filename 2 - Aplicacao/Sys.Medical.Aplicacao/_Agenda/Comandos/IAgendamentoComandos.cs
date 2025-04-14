using Atividade01.Dominio.Sistemicas;
using Sys.Medical.Dominio.DTOs;

namespace Sys.Medical.Aplicacao._Agenda.Comandos
{
    public interface IAgendamentoComandos
    {
        public ResultadoGenericoComandos Criar(Agenda agenda);
        public ResultadoGenericoComandos AprovarAgenda(string codAgenda);
        public ResultadoGenericoComandos CancelarAgenda(string codAgenda);

    }
}
