using Atividade01.Dominio.Sistemicas;
using Sys.Medical.Dominio.DTOs;
using Sys.Medical.Dominio.ViewModel;

namespace Sys.Medical.Aplicacao._Agenda.Comandos
{
    public interface IAgendamentoComandos
    {
        public ResultadoGenericoComandos Atualizar(Agenda agenda);
        public ResultadoGenericoComandos CriarAgendaMensal(AgendaMensal agendaMensal);
        public ResultadoGenericoComandos AgendarConsultaPaciente(AgendarConsultaPaciente agenda);

    }
}
