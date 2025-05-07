using Sys.Medical.Dominio.DTOs;
using Sys.Medical.Dominio.ViewModel;

namespace Sys.Medical.Repositorio.Repositorios.AgendamentoRepositorio.Consultas
{
    public interface IAgendamentoConsultasRepositorio
    {
        public IEnumerable<Agenda> ObterPorMedico(string codMedico);
        public IEnumerable<Agenda> ObterPorPaciente(string codMedico);
        public IEnumerable<Agenda> ObterLista();
        public Agenda? ObterAgenda(string codAgenda);
        public AgendaSaida? ObterAgendaSaida(string codAgenda);
        public IEnumerable<AgendaSaida> ObterPorFiltro(FiltroAgenda filtro);

    }
}
