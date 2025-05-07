using Sys.Medical.Dominio.DTOs;
using Sys.Medical.Dominio.ViewModel;

namespace Sys.Medical.Aplicacao._Agenda.Consultas
{
    public interface IAgendamentoConsultas
    {
        public IEnumerable<Agenda> ObterPorMedico(string codMedico);
        public IEnumerable<Agenda> ObterPorPaciente(string codPaciente);
        public IEnumerable<Agenda> ObterLista();
        public IEnumerable<AgendaSaida> ObterPorFiltro(FiltroAgenda filtro);
        public Agenda? ObterAgenda(string codAgenda);
        public AgendaSaida? ObterAgendaSaida(string codAgenda);

    }
}
