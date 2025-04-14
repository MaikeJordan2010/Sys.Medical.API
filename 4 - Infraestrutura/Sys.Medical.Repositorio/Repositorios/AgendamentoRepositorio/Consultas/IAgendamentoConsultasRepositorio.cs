using Sys.Medical.Dominio.DTOs;

namespace Sys.Medical.Repositorio.Repositorios.AgendamentoRepositorio.Consultas
{
    public interface IAgendamentoConsultasRepositorio
    {
        public IEnumerable<Agenda> ObterPorMedico(string codMedico);
        public IEnumerable<Agenda> ObterLista();
        public Agenda? ObterAgenda(string codAgenda);

    }
}
