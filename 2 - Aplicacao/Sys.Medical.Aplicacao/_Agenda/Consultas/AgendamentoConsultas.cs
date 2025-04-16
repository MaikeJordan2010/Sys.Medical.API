using Sys.Medical.Dominio.DTOs;
using Sys.Medical.Dominio.ViewModel;
using Sys.Medical.Repositorio.Repositorios.AgendamentoRepositorio.Consultas;

namespace Sys.Medical.Aplicacao._Agenda.Consultas
{
    public class AgendamentoConsultas : IAgendamentoConsultas
    {
        private readonly IAgendamentoConsultasRepositorio _agendamentoConsultasRepositorio;

        public AgendamentoConsultas(IAgendamentoConsultasRepositorio agendamentoConsultasRepositorio)
        {
            _agendamentoConsultasRepositorio = agendamentoConsultasRepositorio;
        }
        public Agenda? ObterAgenda(string codAgenda)
        {
            if (!string.IsNullOrEmpty(codAgenda))
            {
                return _agendamentoConsultasRepositorio.ObterAgenda(codAgenda);
            }

            return null;
        }

        public AgendaSaida? ObterAgendaSaida(string codAgenda)
        {
            if (!string.IsNullOrEmpty(codAgenda))
            {
                return _agendamentoConsultasRepositorio.ObterAgendaSaida(codAgenda);
            }

            return null;
        }

        public IEnumerable<Agenda> ObterLista()
        {
            return _agendamentoConsultasRepositorio.ObterLista();
        }

        public IEnumerable<Agenda> ObterPorMedico(string codMedico)
        {
            if (!string.IsNullOrEmpty(codMedico))
            {
                return _agendamentoConsultasRepositorio.ObterPorMedico(codMedico);
            }

            return Enumerable.Empty<Agenda>();
        }

        public IEnumerable<Agenda> ObterPorPaciente(string codPaciente)
        {
            if (!string.IsNullOrEmpty(codPaciente))
            {
                return _agendamentoConsultasRepositorio.ObterPorPaciente(codPaciente);
            }

            return Enumerable.Empty<Agenda>();
        }
    }
}
